using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;


namespace RemoteHostManager
{
    // Modules must be public and inherit from an IModuleBase
    public class CommandModule : ModuleBase<SocketCommandContext>
    {
        private static DiscordSocketClient _client;
        private static readonly ulong myID = 186573035258642432; //This is my Discord ID, not the bot token.

        public static void SetClient(DiscordSocketClient client)
        {
            _client = client;
            return;
        }
        //Helps us by returning remaining strings. Particularly useful in the roll command.
        //First arg is the whole string you want to take from, the second string arg is where we start reading from.
        public static string TextFollowing(string txt, string value)
        {
            if (!String.IsNullOrEmpty(txt) && !String.IsNullOrEmpty(value))
            {
                int index = txt.IndexOf(value);
                if (-1 < index)
                {
                    int start = index + value.Length;
                    if (start <= txt.Length)
                    {
                        return txt[start..];
                    }
                }
            }
            return null;
        }
        //Helps us by returning beforehand strings. Useful in situations like just removing the filename from the extension.
        public static string TextBefore(string txt, string value)
        {
            if (!String.IsNullOrEmpty(txt) && !String.IsNullOrEmpty(value))
            {
                int index = txt.IndexOf(value);
                if (-1 < index)
                {
                    int start = index;
                    if (start <= txt.Length)
                    {
                        return txt.Substring(0, start);
                    }
                }
            }
            return null;
        }
       

        //Change status
        [Command("setstatus")]
        public async Task ChangeStatus([Remainder] string text)
        {
            if (Context.User.Id == myID)
            {
                await _client.SetGameAsync(text, null, ActivityType.Watching);
                await ReplyAsync("changed status to " + text);
            }
            else { await ReplyAsync("Sorry, you do not have permission to run this command"); }
        }

        //Disconnects the robot (This closes the program!)
        [Command("shutdown")]
        [RequireUserPermission(GuildPermission.Administrator)]
        [RequireBotPermission(ChannelPermission.ManageMessages)]//This is here moreso for an example.
        public async Task SetOffline()
        {
            await ReplyAsync("I am going offline");
            //Check the UserStatus Enum for all possible values. 0 means Offline.
            await _client.SetStatusAsync(UserStatus.Offline);
            await _client.StopAsync();
            Environment.Exit(4000);
        }

        //Generates invite link
        [Command("invite")]
        public async Task GetOAuth()
        {
            if (Context.User.Id == myID) await ReplyAsync("https://discord.com/api/oauth2/authorize?client_id=847920785460166696&permissions=2349333568&scope=bot");
        }

        [Command("help")]
        public async Task ShowHelp()
        {
            await ReplyAsync("status\n");
            if (Context.User.Id == myID) await Context.User.SendMessageAsync("invite\nshutdown\nsetstatus [STRING]\n");
        }

        /// <summary>
        /// Opens a hidden cmd instance and executes the given command through arg
        /// </summary>
        /// <param name="args"></param>
        public void RunCmd(string args)
        {
            Process p = new();
            ProcessStartInfo startInfo = new();
            startInfo.FileName = "cmd.exe";
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.Arguments = $"/C {args}";
            p.StartInfo = startInfo;
            p.Start();
            p.WaitForExit();
           
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //Checks the status of the minecraft server.
        [Command("status")]
        public async Task ShowServerStatus()
        {

        }

        [Command("teamviewer", RunMode = RunMode.Async)]
        public async Task CheckTeamViewer()
        {
            if (Context.User.Id == myID)
            {
                Process[] localAll = Process.GetProcesses();
                for (int x = 0; x < localAll.Length; x++)
                {
                    Console.WriteLine(localAll[x].ProcessName);
                    if (localAll[x].ProcessName.ToLower() == "teamviewer")
                    {
                        await Context.User.SendMessageAsync("Teamviewer is currently running");
                        return;
                    } else
                    {
                        //Restart TV process.
                        RunCmd("taskkill /f /im teamviewer.exe /t");
                    }
                }
            } else
            {
                await ReplyAsync("You do not have permission to use this command!");
            }
        }

    }
}
