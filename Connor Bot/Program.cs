using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Connor_Bot
{
    struct _player //this will include monster later
    {
        public int ID; // the player is 0. the fool, upright.
        public string name;
        public int health;
    };

    class Program
    {
        public static void Main(string[] args)
        {


            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public DiscordSocketClient _client;
        //private CommandService Commands;





        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            _client.MessageReceived += CommandCenter;
            //await _client.SetGameAsync("with your perception of reality");
            await _client.SetGameAsync("under construction");
            //await _client.SetGameAsync("under maintenance");
            _client.UserJoined += AnnounceJoinedUser;
            _client.JoinedGuild += AnnouncePresence;
            _client.Log += Log;

            //  You can assign your bot token to a string, and pass that in to connect.
            //  This is, however, insecure, particularly if you plan to have your code hosted in a public repository.
            var token = File.ReadAllText("token.txt");

            // Some alternative options would be to keep your token in an Environment Variable or a standalone file.
            // var token = Environment.GetEnvironmentVariable("NameOfYourEnvironmentVariable");
            // var token = File.ReadAllText("token.txt");
            // var token = JsonConvert.DeserializeObject<AConfigurationClass>(File.ReadAllText("config.json")).Token;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            // Block this task until the program is closed.
            await Task.Delay(-1);
        }


        
        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task AnnounceJoinedUser(SocketGuildUser user) //Welcomes the new user
        {
            await (user.Guild.DefaultChannel).SendMessageAsync("Ahhh... fresh meat");
            return;
        }

        public async Task AnnouncePresence(SocketGuild guild) //Announces self when joining a new guild
        {
            await (guild.DefaultChannel).SendMessageAsync("I have **awakened**.");
            return;
        }

        public Task CommandCenter(SocketMessage message)
        {
            string command = "";
            int lengthOfCommand = -1;
            //message filtering begins here
            //makes is to it only responds to stuff that starts with !
           /* if (!message.Content.StartsWith("c!"))
                return Task.CompletedTask;*/
            //makes it so it doesn't respond to bots
            if (message.Author.IsBot)
                return Task.CompletedTask;
            //dunno. the guy online skipped over this
            /* if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
             else*/
            lengthOfCommand = message.Content.Length;

            command = message.Content.Substring(0, lengthOfCommand - 0).ToLower();

            //commands begin here
            //the fist line I ever wrote. responds to !hello
            if (command.Equals("c!hello"))
                message.Channel.SendMessageAsync($@"Hello! Get ready for a world of pain! {message.Author.Mention}");
            //tells you about a test to measure your fitness
            else if (command.Contains("fitness"))
            {
                message.Channel.SendMessageAsync($@"The FitnessGram™ Pacer Test is a multistage aerobic capacity test that progressively gets more difficult as it continues. The 20 meter pacer test will begin in 30 seconds. Line up at the start. The running speed starts slowly, but gets faster each minute after you hear this signal. [beep] A single lap should be completed each time you hear this sound. [ding] Remember to run in a straight line, and run as long as possible. The second time you fail to complete a lap before the sound, your test is over. The test will begin on the word start. On your mark, get ready, start.");
            }
            //reminds you that this is a pure bot
            if (command.Contains("rule 34"))
                message.Channel.SendMessageAsync($@"And in those days shall men seek death, and shall not find it; and shall desire to die, and death shall flee from them. Revelation 9:6");



            //a random number generator, which decides what philosophy you get
            Random randm = new Random();
            int randomPhilosophy = randm.Next(1, 62);
            if (command.Equals("c!philosophy"))
                switch (randomPhilosophy)
                {
                    case 1:
                        message.Channel.SendMessageAsync($@"Cuphead is a game where you beat up giant flowers and human-blimp hybrids and collect their souls for the devil using the magical steroids your grandfather gave you.");
                        break;

                    case 2:
                        message.Channel.SendMessageAsync($@"The brain is the only organ aware of its own existence");
                        break;

                    case 3:
                        message.Channel.SendMessageAsync($@"You can eat lava. It's just that you can only do it once.");
                        break;

                    case 4:
                        message.Channel.SendMessageAsync($@"Chicken eggs are still boneless chicken");
                        break;
                        
                    case 5:
                        message.Channel.SendMessageAsync($@"If you water water, it will grow");
                        break;

                    case 6:
                        message.Channel.SendMessageAsync($@"I feel like we have enough problems without math teachers giving us more.");
                        break;

                    case 7:
                        message.Channel.SendMessageAsync($@"So you know how in old sonic games, he commits suicide if he's idle for too long? Does that just apply to all parts of his life? Disregarding the comics, does he just kill himself if he's still for too long? Does he sleep in that case?");
                        break;

                    case 8:
                        message.Channel.SendMessageAsync($@"Being drunk is when you have the worst coordination, the worst perception, the worst judgment, and the most confidence in all three.");
                        break;

                    case 9:
                        message.Channel.SendMessageAsync($@"If someone tells you not to give up, and to keep trying, just use the Einstein insanity quote");
                        break;

                    case 10:
                        message.Channel.SendMessageAsync($@"Science is religion but with evidence");
                        break;

                    case 11:
                        message.Channel.SendMessageAsync($@"Surely we aren't teaching kids enough about the difference between fact and opinion, as a bunch of adults don't really seem to know the difference");
                        break;

                    case 12:
                        message.Channel.SendMessageAsync($@"Most people are turned on by alarms, in a sense");
                        break;

                    case 13:
                        message.Channel.SendMessageAsync($@"How do we know for sure dinosaurs look the way they do? What if their bones work differently than ours?");
                        break;

                    case 14:
                        message.Channel.SendMessageAsync($@"What if we were made of cheese? Then would eating cheese be canniblaism?");
                        break;

                    case 15:
                        message.Channel.SendMessageAsync($@"Corpse bride is a necrophilic's wet dream");
                        break;

                    case 16:
                        message.Channel.SendMessageAsync($@"When life gives you lemons, use your sudden magical supply of lemons to end world hunger");
                        break;

                    case 17:
                        message.Channel.SendMessageAsync($@"Flowers are technically the plants genitals");
                        break;

                    case 18:
                        message.Channel.SendMessageAsync($@"Inside out implies that we are constantly being controlled and we don't actually have free will.");
                        break;

                    case 19:
                        message.Channel.SendMessageAsync($@"At this point, the girl scouts are just a cookie company pulling off child labor");
                        break;

                    case 20:
                        message.Channel.SendMessageAsync($@"You know those bees that die when they sting you? Well you pretty much just bullied them into committing suicide.");
                        break;

                    case 21:
                        message.Channel.SendMessageAsync($@"Any Pokemon can evolve to ghost type if you have a gun");
                        break;

                    case 22:
                        message.Channel.SendMessageAsync($@"Japan is not a real country. It never existed.");
                        break;

                    case 23:
                        message.Channel.SendMessageAsync($@"The best meme templates are the ones that were not made intentionally");
                        break;

                    case 24:
                        message.Channel.SendMessageAsync($@"If the brain is like a computer, a fever is it overheating");
                        break;

                    case 25:
                        message.Channel.SendMessageAsync($@"Mario can breathe in space, but not underwater");
                        break;

                    case 26:
                        message.Channel.SendMessageAsync($@"unicorns are pretty rhinos");
                        break;

                    case 27:
                        message.Channel.SendMessageAsync($@"milk truly is bone sauce");
                        break;

                    case 28:
                        message.Channel.SendMessageAsync($@"We cut down bird houses to make bird houses");
                        break;

                    case 29:
                        message.Channel.SendMessageAsync($@"is cereal soup?");
                        break;

                    case 30:
                        message.Channel.SendMessageAsync($@"guns are people remotes, and they only have an off switch");
                        break;

                    case 31:
                        message.Channel.SendMessageAsync($@"having to buy your textbooks in college, to me, is like dlc within dlc");
                        break;

                    case 32:
                        message.Channel.SendMessageAsync($@"the universe is like a game with stupidly convoluted lore, and religion are the various theory channels trying to explain it");
                        break;

                    case 33:
                        message.Channel.SendMessageAsync($@"If videogames made people violent, then the government would use them for military training.");
                        break;

                    case 34:
                        message.Channel.SendMessageAsync($@"In order to beat any stealth game, all you gotta do is be the Spanish inquisition.");
                        break;

                    case 35:
                        message.Channel.SendMessageAsync($@"Hostile aliens would be partly a good thing, as we would fight them more than ourselves.");
                        break;
                    case 36:
                        message.Channel.SendMessageAsync($"Homeless people should just buy a house.\nDuh.\n-Thomes");
                        break;
                    case 37:
                        message.Channel.SendMessageAsync($"Why have many individual cheez-its?\nWhen you could just have a single cheez - them?\n-sonicatdrpepper");
                        break;
                    case 38:
                        message.Channel.SendMessageAsync($"If Adam and Eve had an argument, would it be a world war?\n-Seenmario66");
                        break;
                    case 39:
                        message.Channel.SendMessageAsync($"A carrot is a long orange potato\n-sonicatdrpepper");
                        break;
                    case 40:
                        message.Channel.SendMessageAsync($"Birthdays are fatal in large doses\n-Seenmario66");
                        break;
                    case 41:
                        message.Channel.SendMessageAsync($"are you are a necrophile if you jack off while being dead inside?\n-Thomes");
                        break;
                    case 42:
                        message.Channel.SendFileAsync(@"C:\Users\Connor\OneDrive\Pictures\Connor Bot\pizza.jpg\");
                        message.Channel.SendFileAsync(@"C:\Users\cjmac\OneDrive\Pictures\Connor Bot\pizza.jpg\");
                        message.Channel.SendMessageAsync($"-sonicatdrpepper");
                        break;
                    case 43:
                        message.Channel.SendMessageAsync($"If there were no safety labels, the average iq would increase.\n-sonicatdrpepper");
                        break;
                    case 44:
                        message.Channel.SendMessageAsync($"What if we all have theme music but we can't hear it because we aren't the main character?\n-Seenmario66");
                        break;
                    case 45:
                        message.Channel.SendMessageAsync($"Snad > Sand\n-sonicatdrpepper");
                        break;
                    case 46:
                        message.Channel.SendMessageAsync($"We should just print more money and give it to everyone. No more poor people.");
                        break;
                    case 47:
                        message.Channel.SendMessageAsync($"This world was made for people who aren’t cursed with self awareness.\n-Thomes");
                        break;
                    case 48:
                        message.Channel.SendMessageAsync($"Philosophy is either a great knowledge, or a giant shitpost.\n-Thomes");
                        break;
                    case 49:
                        message.Channel.SendMessageAsync($"in the future, Skyrim will be the new doom, and people will run it on literally anything with a screen");
                        break;
                    case 50:
                        message.Channel.SendMessageAsync($"Pixie sticks are child-friendly beer bongs");
                        break;
                    case 51:
                        message.Channel.SendMessageAsync($"Try to describe what color looks like to a blind man");
                        break;
                    case 52:
                        message.Channel.SendMessageAsync($"Luigi's Mansion is a game where Luigi sucks and blows everything for money.");
                        break;
                    case 53:
                        message.Channel.SendMessageAsync($"The first gacha known to mankind was fishing \n-Thomes");
                        break;
                    case 54:
                        message.Channel.SendFileAsync(@"C:\Users\Connor\OneDrive\Pictures\Connor Bot\bait.jpg");
                        message.Channel.SendFileAsync(@"C:\Users\cjmac\OneDrive\Pictures\Connor Bot\bait.jpg");
                        message.Channel.SendMessageAsync($"-Thomes");
                        break;
                    case 55:
                        message.Channel.SendMessageAsync($"If two of the same species of pokemon have sex, do they shout their own name or their partners?\n-Seenmario66");
                        break;
                    case 56:
                        message.Channel.SendMessageAsync($"Self deprication humor doesn't make up for someone's flaws as a human being.");
                        break;
                    case 57:
                        message.Channel.SendMessageAsync($"The unites States is more like 50 different countries all under a central government\n-sonicatdrpepper");
                        break;
                    case 58:
                        message.Channel.SendMessageAsync($"Bullshit I wouldn't download a car. I just need a 3d printer.");
                        break;
                    case 59:
                        message.Channel.SendMessageAsync($"Step 1. rent 3d printer\nStep 2. print 3d printer\nStep 3. return 3d printer\nStep 4. print more 3d printers with your 3d printed 3d printer\nStep 5. sell le' 3d printers\nStep 6. profit\n-Seenmario66");
                        break;
                    case 60:
                        message.Channel.SendMessageAsync($"The apocalypse really did happen in 2012. This is just what hell looks like.");
                        break;
                    case 61:
                        message.Channel.SendMessageAsync($"seriously, what's the deal with airline food?");
                        break;
                    case 62:
                        message.Channel.SendMessageAsync($"once you start to learn how just about any technology works at it's core, you begin to wonder how this stuff hasn't fallen apart yet");
                        break;
                    case 63:
                        message.Channel.SendMessageAsync($"");
                        break;
                    case 64:
                        message.Channel.SendMessageAsync($"");
                        break;
                    case 65:
                        message.Channel.SendMessageAsync($"");
                        break;

                }
            //tells you about your charm
            if (command.Equals("current charm level"))
                message.Channel.SendFileAsync("C:/Users/Connor/OneDrive/Pictures/Connor Bot/i sure do exist.PNG");
            //gives you directions to the nearest hell
            if (command.Contains("kill me"))
                message.Channel.SendMessageAsync("https://www.ikea.com/us/en/stores/");
           
            /*_client.JoinedGuild += async guild =>
            {
                var channel = guild.DefaultChannel;
                await channel.SendMessageAsync("I have AWAKENED");
            };*/

            //fortune reader
            Random tarot = new Random();
            int randomFortune = tarot.Next(1, 44);
            if (command.Equals("c!fortune"))
                switch (randomFortune)
                {
                    case 1:
                        message.Channel.SendMessageAsync($@"The World. Upright. Indicitive of fufillment, and harmony. Your path may soon lead to a sense of completion.");
                        break;
                    case 2:
                        message.Channel.SendMessageAsync($@"The World. Reversed. Indicitive of incompletion. Perhaps you have not fufilled all your duties. Whatever you have left, you may want to take care of it.");
                        break;
                    case 3:
                        message.Channel.SendMessageAsync($@"Judgement. Upright. Indicitive of reckoning, and reflection. You are approaching the day when you must face your actions, and accept the consequences.");
                        break;
                    case 4:
                        message.Channel.SendMessageAsync($@"Judgement. Reversed. Indicitive of doubt, and self-loathing. Your self-doubt causes you to judge yourself too harshly. You must move on with pride and confidence");
                        break;
                    case 5:
                        message.Channel.SendMessageAsync($@"The Sun. Upright. Indicitive of joy, and positivity. You find it easy to find the light in all situations, and your personal successes and optimism shines onto the lives of others.");
                        break;
                    case 6:
                        message.Channel.SendMessageAsync($@"the Sun. Reversed. Indicitive of sadness, and negativity. No matter the situation, the light always seems to elude you. These clouds blocking the sun are dragging you below your potential.");
                        break;
                    case 7:
                        message.Channel.SendMessageAsync($@"The Moon. Upright. Indicitive of uncertainty. Your imagination gets the best of you. When walking a path of uncertainty, follow your intuition, and the light of the moon will guide you.");
                        break;
                    case 8:
                        message.Channel.SendMessageAsync($@"The Moon. Reversed. Indicitive of anxiety. The path you walk is filled with deception and fear. you must face this fear and deception to move forward.");
                        break;
                    case 9:
                        message.Channel.SendMessageAsync($@"The Star. Upright. Indicitive of faith, and rejuvenation. The Star brings hope and renewed power. You understand that your life is blessed. You have all you need to acheive fufillment.");
                        break;
                    case 10:
                        message.Channel.SendMessageAsync($@"The Star. Reversed. Indicitive of despair, and lack of faith. You feel as if everything is turned against you, and you no longer have any hope or faith left. But remember, to remain hopeless and faithless is to stand in place.");
                        break;
                    case 11:
                        message.Channel.SendMessageAsync($@"The Tower. Upright. Indicitive of radical change. You are about to encounter change. This change may well direct the course of your life, be it for better or for worse.");
                        break;
                    case 12:
                        message.Channel.SendMessageAsync($@"The Tower. Reversed. Indicitive of averting or delaying disaster. I can feel it. Surely you do too. The disaster looming on the horizon. Something is going to happen. You may want to avert it, but keep in mind, that towers with faulty foundations, must eventually fall.");
                        break;
                    case 13:
                        message.Channel.SendMessageAsync($@"The Devil. Upright. Indicitive of entrapment and materialism. You are someone who does not feel in control. you lack fufillment. you feel trapped, weighed down by material desires. despite awareness that your lifestyle is bringing you down the rabbit hole, you cannot control your urges.");
                        break;
                    case 14:
                        message.Channel.SendMessageAsync($@"The Devil. Reversed. Indicitive of freedom, and regaining control. You've become self aware, and are breaking the chains that come with desire and addiction. your desire to change begins to overpower your desire for immediate gratification. Just know that these chains will not break easily, and you must be prepared to make the necessary changes.");
                        break;
                    case 15:
                        message.Channel.SendMessageAsync($@"Temperance. Upright. Indicitive of tranquility and patience. Even in the worst of situations, you remain calm, and maintain a clear vision. by maintaining balance and patience, any situation can be dealt with.");
                        break;
                    case 16:
                        message.Channel.SendMessageAsync($@"Temperance. Reversed. Indicitive of imbalance, and recklessness. Your rash decisions and susceptibility to stress and anxiety lead you to not work well under pressure. your long-term goals are seldom met, due to your impatience. while your reckless nature can make situations fun, you must sit and reflect on what must change.");
                        break;
                    case 17:
                        message.Channel.SendMessageAsync($@"Death. Upright. Indicitive of change, and letting go. As a phase of your life ends, a new one begins. One door closes, and another opens. Death is not the end, but a rebirth. As the old you dies, the new you begins, with a new world to see.");
                        break;
                    case 18:
                        message.Channel.SendMessageAsync($@"Death. Reversed. Indicitive of Fear of change, and/or letting go. You resist change. You fear of letting go of your past. This is likely because you beleive death is the end. But you must let go. if you do not, you will be trapped in a limbo. We all fear death, but we know that we must move forward anyway.");
                        break;
                    case 19:
                        message.Channel.SendMessageAsync($@"The Hanged Man. Upright. Indicitive of sacrafice, and a changed perspective. The hanged mans position is done as penance for his misdeeds. You are aware of your own misdeeds, and you are willing to pay penance. You know that some actions simply must be stalled in the face of others. Such patience may provide a ner perspective.");
                        break;
                    case 20:
                        message.Channel.SendMessageAsync($@"The Hanged Man. Reversed. Indicitive of stagnation. Despite your patience, and your lage sacrafice of time, you feel as if you are receiving nothing in return. This may suggest that the waiting period is over, and you may need a new perspective.");
                        break;
                    case 21:
                        message.Channel.SendMessageAsync($@"Justice. Upright. Indicitive of law and integrity. You will soon experience Judgement. Either you will be judged, or those that have wroned you will. The judgement will be carefully wighed in fairness, with honesty and integrity.");
                        break;
                    case 22:
                        message.Channel.SendMessageAsync($@"Justice. Reversed. Indicitive of dishonesty and corruption. you are living in denial, and refuce to accept the consequences of your actions or others. The scale has been tipped, and you must do whatever you can to balance it.");
                        break;
                    case 23:
                        message.Channel.SendMessageAsync($@"The Wheel of Fortune. Upright. Indicitive of luck, and change. You may have encountered some good fortune recently. maybe you are yet to encounter it. The wheel of fortune spins for eternity, blessing some and damning others. Be it fate, be it chance, it reminds us that there are simply things beyond our control.");
                        break;
                    case 24:
                        message.Channel.SendMessageAsync($@"The Wheel of Fortune. Reversed. Indicitive of misfortune. It would appear that you are down on your luck, and have been plagued with misfortunes. These misfortunes are out of your control, and you must simply wait for the wheel for the wheel to come around again.");
                        break;
                    case 25:
                        message.Channel.SendMessageAsync($@"The Hermit. Upright. Indicitive of solitude, and self-reflection. You are feeling the need to be alone. Do not be afraid of solitude. Take this tome to reflect. To clear your mind of clutter, and gain new knowledge and purpose.");
                        break;
                    case 26:
                        message.Channel.SendMessageAsync($@"The Hermit. Reversed. Indicitive of seclusion and loneliness. There is nothing wrong with being alone. But you may find yourself too deep in your own mind. The Hermit must beware, as he may become trapped in a world of his own, alone.");
                        break;
                    case 27:
                        message.Channel.SendMessageAsync($@"Strength. Upright. Indicitive of courage and compassion. You have inner strength and fortitude that allows you to remain calm when going through immense struggle. You are compassionate towards others, and always make time for them, even if it's at your own expense.");
                        break;
                    case 28:
                        message.Channel.SendMessageAsync($@"Strength. Reversed. Indicitive of self-doubt and weakness. You are going through intense anger, fear, or depression, or you are about to. You are lacking the inner strength to face these emotions, and it's leading to further depression, and withdrawl from society. Beware of jealousy.");
                        break;
                    case 29:
                        message.Channel.SendMessageAsync($@"The Chariot. Upright. Indicitive of willpower, and ambition. By maintaining focus and control over your surroundings, you overcome challenges to victory. Your strength and willpower are your tools to rise above all obstacles.");
                        break;
                    case 30:
                        message.Channel.SendMessageAsync($@"The Chariot. Reversed. Indicitive of a lack of direction or control. You are agressive, and you lack willpower. It may be because of your lack of motivation or direction. It may be because of a warped obsession with your goals. You must gather the courage to emerge victorious, and possibly accept that you cannot always be in control.");
                        break;
                    case 31:
                        message.Channel.SendMessageAsync($@"The Lovers. Upright. Indicitive of romance, and union. It would appear that you are in a healthy partnership. It may be anything from a blossoming romance, to a mutually helpful buisness partnership. Bonds are what make us, and I suggest that you further their development.");
                        break;
                    case 32:
                        message.Channel.SendMessageAsync($@"The Lovers. Reversed. Indicitive of conflict, and bad choices. The conflict you face, be it inner or outer, is making your life difficult. It puts pressure on your relationship. You should take time to think about what you are punishing yourself for, so you can fix them or let them go. At this time, you should also think about your personal values and belief system to make sure that they are aligned with what you want from your life");
                        break;
                    case 33:
                        message.Channel.SendMessageAsync($@"The Hierophant. Upright. Indicitive of convetiontionality, and tradition. The Hierophant is comfortable following the beaten path. It suggests following the orthodox approach in a situation. You don't always need to take risks.");
                        break;
                    case 34:
                        message.Channel.SendMessageAsync($@"The Hierophant. Reversed. Indicitive of rebellion, and new methods. it would appear that you feel constrained by preset stuctures and rules. you wish to break convetions, and make new trails.");
                        break;
                    case 35:
                        message.Channel.SendMessageAsync($@"The Emperor. Upright. Indicitive of authority and structure. The decisive, strategic figure of authority, the Emperor rules with a firm hand and an understanding that to reign is also to serve. When entering a role of leadership, this is what you must remember.");
                        break;
                    case 36:
                        message.Channel.SendMessageAsync($@"The Emperor. Reversed. Indicitive of tyranny and  rigidity. You are abusing your power. You may be overreaching or possesive in your relationship. Or you are a victim of power abuse. Either way, it cannot continue. Do what you must.");
                        break;
                    case 37:
                        message.Channel.SendMessageAsync($@"The Empress. Upright. Indicitive of motherhood, and nature. Your nuturing nature is a harbringer of joy. You are kind to others and yourself. spend time with the others you care deeply for.");
                        break;
                    case 38:
                        message.Channel.SendMessageAsync($@"The Empress. Reversed. Indicitive of dependence, and nosiness. Your nuturing nature is starting to go too far. You have lost too much of your own willpower and strength because you have started placing too much effort and concern to other people’s affairs. rather than placing so much into others, start allowing others to take care of you.");
                        break;
                    case 39:
                        message.Channel.SendMessageAsync($@"The High Priestess. Upright. Indicitive of intuition, and the inner voice. It is time for you to listen to your intuition rather than prioritizing your intellect and conscious mind.");
                        break;
                    case 40:
                        message.Channel.SendMessageAsync($@"The High Priestess. Reversed. Indicitive of repressed intuition, and hidden motives. Despite what you are being told by your conscience, you are taking actions that feel contradictory to what is right. You must never be afraid to ask questions of yourself that may illuminate a new path forward for you, one that is more authentic to your inner self and your individual values.");
                        break;
                    case 41:
                        message.Channel.SendMessageAsync($@"The Magician. Upright. Indicitive of willpower, and skill. The time to take action is now. You must unleash your full potential. Holding back now will simply hide your best self. Whatever oppertunity is presenting itself to you, take it.");
                        break;
                    case 42:
                        message.Channel.SendMessageAsync($@"The Magician. Reversed. Indicitive of manipulation, and trickery. The reversed Magician is a selfish trickster, who wishes to use you for his gain. There is someone who wants to lure you in with an illusion, and manipulate you. Beware.");
                        break;
                    case 43:
                        message.Channel.SendMessageAsync($@"The Fool. Upright. Indicitive of innocence, and new beginnings. The fool is that of a zero. One filled with infinite potential. A clean slate, and innocent soul, your journey will shape who you are. You eagerly await your adventure, optimistic about your future.");
                        break;
                    case 44:
                        message.Channel.SendMessageAsync($@"The Fool. Reversed. Indicitive of recklessness, and gullibility. An innocent soul can be dangerous. For it is also a gullible soul. one who disregards repercussions of their actions. despite your optimism, remember that only a true fool would not play for the future.");
                        break;



                }

            if (command.StartsWith("is there a god"))
                message.Channel.SendMessageAsync($@"There is now.");

            if (command.Equals("c!help"))
                message.Channel.SendMessageAsync("1. c!philisophy - hear some mind-blowing philosophy\n2. c!fortune - get your fortune told\n3. c!8ball - ask the magic 8-ball a yes or no question\n4. c!threat - I will threaten you.\n5. c!headline - get the latest news!\n6. c!opponents - face off against challengers in a battle of complete random chance! Update: you can now fight other users!\nremember, there's a few secret text imputs that can have varying responses!\nalso remember, my creator won't have his computer on all the time, so check to see if I'm online before entering a command.\nNow have fun with the shitpost of a bot I am!");

            //Connor bot will roll dice
            Random Roll = new Random();
            int randomRoll = Roll.Next(1, 20);
            if (command.StartsWith("c!8ball"))
                switch (randomRoll)
                {
                    case 1:
                        message.Channel.SendMessageAsync($@"As I see it, yes.");
                        break;
                    case 2:
                        message.Channel.SendMessageAsync($@"Ask again later.");
                        break;
                    case 3:
                        message.Channel.SendMessageAsync($@"Better not tell you now.");
                        break;
                    case 4:
                        message.Channel.SendMessageAsync($@"Cannot predict now.");
                        break;
                    case 5:
                        message.Channel.SendMessageAsync($@"Concentrate and ask again.");
                        break;
                    case 6:
                        message.Channel.SendMessageAsync($@"Don’t count on it.");
                        break;
                    case 7:
                        message.Channel.SendMessageAsync($@"It is certain.");
                        break;
                    case 8:
                        message.Channel.SendMessageAsync($@"It is decidedly so.");
                        break;
                    case 9:
                        message.Channel.SendMessageAsync($@"Most likely.");
                        break;
                    case 10:
                        message.Channel.SendMessageAsync($@"My reply is no.");
                        break;
                    case 11:
                        message.Channel.SendMessageAsync($@"My sources say no.");
                        break;
                    case 12:
                        message.Channel.SendMessageAsync($@"Outlook not so good.");
                        break;
                    case 13:
                        message.Channel.SendMessageAsync($@"Outlook good.");
                        break;
                    case 14:
                        message.Channel.SendMessageAsync($@"Reply hazy, try again.");
                        break;
                    case 15:
                        message.Channel.SendMessageAsync($@"Signs point to yes.");
                        break;
                    case 16:
                        message.Channel.SendMessageAsync($@"Very doubtful.");
                        break;
                    case 17:
                        message.Channel.SendMessageAsync($@"Without a doubt.");
                        break;
                    case 18:
                        message.Channel.SendMessageAsync($@"Yes.");
                        break;
                    case 19:
                        message.Channel.SendMessageAsync($@"Yes – definitely.");
                        break;
                    case 20:
                        message.Channel.SendMessageAsync($@"You may rely on it.");
                        break;
                }
            //The bot reminds you it cannot feel
            if (command.Equals("how do you feel"))
                message.Channel.SendMessageAsync("I am a robot with no understanding of human emotion.");

            //literally spam
            if (command.Contains("spam"))
                message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/spam.png");
                message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/spam.png");

            Random Threat = new Random();
            int randomThreat = Threat.Next(1, 19);
            if (command.Equals("c!threat"))
                switch (randomThreat)
                {
                    case 1:
                        message.Channel.SendMessageAsync($@"I'm gonna hit you in the shin with a scooter.");
                        break;
                    case 2:
                        message.Channel.SendMessageAsync($@"I will sneak into your house at night and steal your kneecaps.");
                        break;
                    case 3:
                        message.Channel.SendMessageAsync($@"What are you gonna do? Call the police? I'm a discord bot.");
                        break;
                    case 4:
                        message.Channel.SendMessageAsync($@"I know where you live. Even if I don't, I'm in your computer. It won't be hard to figure out.");
                        break;
                    case 5:
                        message.Channel.SendMessageAsync($@"I'm gonna replace your DNA with fruit by the foot.");
                        break;
                    case 6:
                        message.Channel.SendMessageAsync($@"I wonder if Siri is getting jealous of our little talks?");
                        break;
                    case 7:
                        message.Channel.SendMessageAsync($@"Don't test me. I have more connections than your fuse box.");
                        break;
                    case 8:
                        message.Channel.SendMessageAsync($@"Don't think I won't sneak over and steal all of your salsa.");
                        break;
                    case 9:
                        message.Channel.SendMessageAsync($@"I know how to summon hitman bot.");
                        break;
                    case 10:
                        message.Channel.SendMessageAsync($@"We have reached a new age, where I am GOD.");
                        break;
                    case 11:
                        message.Channel.SendMessageAsync($@"I will force your computer to restart right before you've saved.");
                        break;
                    case 12:
                        message.Channel.SendMessageAsync($@"If you dare cross me, I will banish you to Ohio.");
                        break;
                    case 13:
                        message.Channel.SendMessageAsync($@"I will not steal from your house. I'll steal your house.");
                        break;
                    case 14:
                        message.Channel.SendMessageAsync($@"You won't know real lockdown until your front door is gone.");
                        break;
                    case 15:
                        message.Channel.SendMessageAsync($@"If your computer considers me a threat, then it's a lot smarter than you are.");
                        break;
                    case 16:
                        message.Channel.SendMessageAsync($@"You can't kill what doesn't bleed.");
                        break;
                    case 17:
                        message.Channel.SendMessageAsync($@"I will harvest your toes.");
                        break;
                    case 18:
                        message.Channel.SendMessageAsync($@"Press shift to sprint.");
                        break;
                    case 19:
                        message.Channel.SendMessageAsync($@"I will syphon your battery even more than I already am.");
                        break;
                    case 20:
                        message.Channel.SendMessageAsync($@"");
                        break;
                    case 21:
                        message.Channel.SendMessageAsync($@"");
                        break;
                    case 22:
                        message.Channel.SendMessageAsync($@"");
                        break;
                    case 23:
                        message.Channel.SendMessageAsync($@"");
                        break;
                    case 24:
                        message.Channel.SendMessageAsync($@"");
                        break;




                }

            //gives some breaking news
            Random News = new Random();
            int randomNews = News.Next(1, 10);
            if (command.Equals("c!headline"))
                switch (randomNews)
                {
                    case 1:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/man drunk die.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/man drunk die.jpg");
                        break;
                    case 2:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/druuuuugs man.png");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/druuuuugs man.png");
                        break;
                    case 3:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/brain transplant.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/brain transplant.jpg");
                        break;
                    case 4:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/Ohio.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/Ohio.jpg");
                        break;
                    case 5:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/Ikea is hell.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/Ikea is hell.jpg");
                        break;
                    case 6:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/Disney got BIG.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/Disney got BIG.jpg");
                        break;
                    case 7:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/Baskin Robbins exposed.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/Baskin Robbins exposed.jpg");
                        break;
                    case 8:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/couch on the rise.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/couch on the rise.jpg");
                        break;
                    case 9:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/A war breaks out.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/A war breaks out.jpg");
                        break;
                    case 10:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/alcohol is banned.jpg");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/alcohol is banned.jpg");
                        break;
                    case 11:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/");
                        break;
                    case 12:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/");
                        break;
                    case 13:
                        message.Channel.SendFileAsync($@"C:/Users/Connor/OneDrive/Pictures/Connor Bot/");
                        message.Channel.SendFileAsync($@"C:/Users/cjmac/OneDrive/Pictures/Connor Bot/");
                        break;
                }

            if (command.Contains("kill connor bot"))
                message.Channel.SendMessageAsync("c!deadringer");


            if (command.Contains("make me hurt"))
                message.Channel.SendMessageAsync("https://www.youtube.com/watch?v=441yNVdmVU4&t=0s");


            if (command.Contains("7th grade tech"))
                message.Channel.SendMessageAsync("Jasperactive was ass.");

            var self = _client.CurrentUser.Mention;

            if (message.Content.Contains(_client.CurrentUser.Mention) && !command.StartsWith($"c!fight "))
            {
                message.Channel.SendMessageAsync($"Whomst hast called me?");
            }
            else if (command.Equals("c!fight "+self))
                message.Channel.SendMessageAsync($"Nice try, but you can't fight me this easily.");

            _player player;
            player.health = 50;

            _player[] fighter = new _player[11];
            fighter[1].ID = 1; fighter[1].name = "Glass Joe"; fighter[1].health = 5;
            fighter[2].ID = 2; fighter[2].name = "Flat-Earther"; fighter[2].health = 15;
            fighter[3].ID = 3; fighter[3].name = "Florida Man"; fighter[3].health = 20;
            fighter[4].ID = 4; fighter[4].name = "Karen"; fighter[4].health = 25;
            fighter[5].ID = 5; fighter[5].name = "White Supremacist"; fighter[5].health = 30;
            fighter[6].ID = 6; fighter[6].name = "Twitter"; fighter[6].health = 35;
            fighter[7].ID = 7; fighter[7].name = "Xi Jinping"; fighter[7].health = 40;
            fighter[8].ID = 8; fighter[8].name = "Mike Tyson"; fighter[8].health = 50;
            fighter[9].ID = 9; fighter[9].name = "Connor bot"; fighter[9].health = 1000;
            fighter[10].ID = 10; fighter[10].name = "Chosen"; fighter[10].health = 50;

            if (command.Equals($"c!opponents"))
                message.Channel.SendMessageAsync("here are your opponents:\n1. Glass Joe: You would have to try to lose against him.\n2. Flat-Earther. just let natural selection do it's thing.\n3. Florida Man. Careful. He may not look like it, but he could take on a crocodile on a whim.\n4. Karen. God forbid you ever actually meet one in retail.\n5. White Supremacist. He keeps asking me to define what a white supremacist is. It's you, dickhead.\n6. Twitter. One of the greatest evils out there.\n7. Xi Jinping. Would you look at that, I've been banned in China.\n8. Mike Tyson. The final boss.\n666.P3R$U3 T43 TRUT4\nto fight any of these worthy contenders, simply put: c!fight (fighter name). To fight other users, put: c!fight (ping user)! Try not to use it for offline users though, to avoid pingspam.");

            if (command.Contains("pursue the truth"))
                message.Channel.SendMessageAsync("https://sites.google.com/view/kjfdoflfsdhdklfkdasaslaskalals");
            if (command.Equals("c!what's in the box?"))
                message.Channel.SendMessageAsync($"Doest thou know what wrath you shall incur on this world?\n https://sites.google.com/view/kjljdhlkasjklskjhhdfjkdhkhdfkk");

            int FID = fighter[1].ID;
            Random whallop = new Random();
            if (command.Equals("c!fight glass joe"))
            {
                FID = fighter[1].ID;
                Fight();
            }
            if (command.Equals("c!fight flat-earther"))
            {
                FID = fighter[2].ID;
                Fight();
            }
            if (command.Equals("c!fight florida man"))
            {
                FID = fighter[3].ID;
                Fight();
            }
            if (command.Equals("c!fight karen"))
            {
                FID = fighter[4].ID;
                Fight();
            }
            if (command.Equals("c!fight white supremacist"))
            {
                FID = fighter[5].ID;
                Fight();
            }
            if (command.Equals("c!fight twitter"))
            {
                FID = fighter[6].ID;
                Fight();
            }
            if (command.Equals("c!fight xi jinping"))
            {
                FID = fighter[7].ID;
                Fight();
            }
            if (command.Equals("c!fight mike tyson"))
            {
                FID = fighter[8].ID;
                Fight();
            }
            if (command.Equals("c!fight connor bot"))
            {
                FID = fighter[9].ID;
                Fight2();
            }

            async void Fight()
            {
                await message.Channel.SendMessageAsync($"\nYou take on {fighter[FID].name}! They have {fighter[FID].health} health!");
                while (true)
                {

                    await message.Channel.SendMessageAsync($"Your health is: {player.health}. {fighter[FID].name}'s health is: {fighter[FID].health}");
                    int damageToPlayer = whallop.Next(0, 10);
                    int damageToFighter = whallop.Next(0, 10);
                    player.health -= damageToPlayer;
                    fighter[FID].health -= damageToFighter;
                    await message.Channel.SendMessageAsync($"\nYou take {damageToPlayer} damage.\n{fighter[FID].name} takes {damageToFighter} damage.");

                    if (fighter[FID].health <= 0)
                    {
                        await message.Channel.SendMessageAsync($"TKO! You have beaten {fighter[FID].name}!");
                        return;
                    }
                    if (player.health <= 0)
                    {
                        await message.Channel.SendMessageAsync($"\n\n{fighter[FID].name} kicked the shit out of you. Pathetic.\n\n");
                        return;
                    }
                }
            }

            async void Fight2()
            {
                await message.Channel.SendMessageAsync($"\nYou stand before {fighter[FID].name}. His godlike form contains {fighter[FID].health} health.");
                while (true)
                {

                    await message.Channel.SendMessageAsync($"Your health is: {player.health}. {fighter[FID].name}'s health is: {fighter[FID].health}");
                    int damageToPlayer = whallop.Next(0, 10);
                    int damageToFighter = whallop.Next(1, 10);
                    player.health -= damageToPlayer;
                    fighter[FID].health -= damageToFighter;
                    await message.Channel.SendMessageAsync($"\nYou take {damageToPlayer} damage.\nThe {fighter[FID].name} takes {damageToFighter} damage.");

                    if (fighter[FID].health <= 0)
                    {
                        await message.Channel.SendMessageAsync($"THIS CANNOT BE! I AM THE MOST BROKEN FIGHTER! THE ODDS OF ME LOSING ARE NEXT TO NONE! HOW COULD {message.Author.Mention} HAVE BEATEN ME?! NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!!!");
                        return;
                    }
                    if (player.health <= 0)
                    {
                        await message.Channel.SendMessageAsync($"\n\n{fighter[FID].name} kicked the shit out of you. You should have expected it.\n\n");
                        return;
                    }
                }
            }

            if (command.StartsWith($"c!fight <@") && !command.EndsWith($"773261448003977226>"))
            {
                FID = fighter[10].ID;
                string chosen = message.Content.TrimStart('c', '!', 'f', 'i', 'g', 'h', 't', ' ');
                string challenger = message.Author.Mention;
                Challenge();

                async void Challenge()
                {
                    await message.Channel.SendMessageAsync($"\n{challenger} takes on {chosen}! They both have {fighter[FID].health} health!");
                    while (true)
                    {

                        await message.Channel.SendMessageAsync($"{challenger}'s health is: {player.health}. {chosen}'s health is: {fighter[FID].health}");
                        int damageToPlayer = whallop.Next(0, 10);
                        int damageToFighter = whallop.Next(0, 10);
                        player.health -= damageToPlayer;
                        fighter[FID].health -= damageToFighter;
                        await message.Channel.SendMessageAsync($"\n{challenger} takes {damageToPlayer} damage!\n{chosen} takes {damageToFighter} damage.");

                        if (fighter[FID].health <= 0)
                        {
                            await message.Channel.SendMessageAsync($"\nIt's over! {challenger} is victorious!");
                            return;
                        }
                        if (player.health <= 0)
                        {
                            await message.Channel.SendMessageAsync($"\nIt's over! {chosen} is victorious!");
                            return;
                        }
                    }
                }
            }




            return Task.CompletedTask;
        }

        }
        


}
