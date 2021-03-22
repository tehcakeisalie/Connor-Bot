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
    class dungeon
    {
        /*if (command.Equals("c!dungeon"))
                Playgame();

            async void Playgame()
            {

                string version = "0.0.1";

                //make the player here
                _player player;
                player.ID = 0; //main player
                player.name = "Player";
                player.health = 50;

                //give the player a location (pX,pY)
                int pX = 5;
                int pY = 5;

                _player[] monster = new _player[10];
                monster[1].ID = 1; monster[1].name = "Small Goat"; monster[1].health = 5;
                monster[2].ID = 2; monster[2].name = "Ripped Goat"; monster[2].health = 50;
                monster[3].ID = 3; monster[3].name = "Classy Goat"; monster[3].health = 15;

                //make some places to go to
                int MaxX = 10; int MaxY = 10;
                _location[,] location = new _location[MaxX, MaxY];
                location[5, 5].locationName = "Home";
                location[5, 6].locationName = "Jailtown"; location[5, 6].description = "You enter a small town. \nAs you scan every direction, you come to the realization that there is crime everywhere you look!\nYou learn that the crime used to be so bad that the jail would fill up.\nAs the jail got bigger to fit more, it enveloped the town. making it into jailtown.";
                location[2, 2].locationName = "The Zither Room"; location[2, 2].description = "As you enter the room, a stange musical chord strikes your ears. \nYou can feel yourself entering a trance."; location[2, 2].monsterID = 3;
                location[7, 7].monsterID = 2;
                location[4, 6].monsterID = 1; location[4, 6].locationName = "Farmyard";
                location[9, 9].locationName = "The Savepoint"; location[9, 9].description = "As you enter the room, a wave of calm washes over you.\nYou are safe.";
                //start the game engine
                Random dice = new Random();
                while (true)
                {

                    //display info about location
                    await message.Channel.SendMessageAsync($"\n\n-----------------------------------------\nYou are at ({pX},{pY})\n*{location[pX, pY].locationName}*\n{location[pX, pY].description}\nYour health is: {player.health}");


                    //battle time
                    if (location[pX, pY].monsterID != 0) //detects a monster. battle below!
                    {
                        int mID = location[pX, pY].monsterID;
                        int damageToPlayer = dice.Next(0, 10); //this can be changed
                        int damageToMonster = dice.Next(0, 10); //this can also be changed
                        player.health -= damageToPlayer;
                        monster[mID].health -= damageToMonster;
                        await message.Channel.SendMessageAsync($"\nYou encounter a {monster[mID].name}! It has {monster[mID].health} health!\nYou take {damageToPlayer} damage.\nThe {monster[mID].name} takes {damageToMonster} damage.");

                        //someone's gotta die
                        if (monster[mID].health <= 0)
                        {
                            await message.Channel.SendMessageAsync($"The {monster[mID].name} has been slain by your hand!");
                            location[pX, pY].monsterID = 0;
                        }
                        if (player.health <= 0)
                        {
                            await message.Channel.SendMessageAsync("\n\nYou have perished\n\n");
                            return;
                        }
                    } //battle ends here

                    //Special rooms
                    if (pX == 9 && pY == 9)
                    {
                        await message.Channel.SendMessageAsync("You rest for a moment, and feel much better.");
                        player.health += 10;
                    }


                    //Ask for a command
                    if (location[pX, pY].monsterID == 0)
                    {
                        await message.Channel.SendMessageAsync("Where will you go?");
                        if (command.Equals("quit"))
                        {
                            await message.Channel.SendMessageAsync("Bye!");
                            return;
                        }
                        if (command.Equals("north"))
                        {
                            pY--;
                        }
                        if (command.Equals("south"))
                        {
                            pY++;
                        }
                        if (command.Equals("east"))
                        {
                            pX++;
                        }
                        if (command.Equals("west"))
                        {
                            pX--;
                        }
                        if (command.Equals("map"))
                        {
                            DrawMap(location, pX, pY);
                        }
                    }
                    pX = Math.Clamp(pX, 0, MaxX - 1);
                    pY = Math.Clamp(pY, 0, MaxY - 1);

                }//end of while true

                async void DrawMap(_location[,] loc, int playerX, int playerY)
                {
                    //https://docs.microsoft.com/en-us/dotnet/api/system.array.length?view=net-5.0
                    //Console.WriteLine(loc.Rank);
                    int xDim = loc.GetUpperBound(0);
                    int yDim = loc.GetUpperBound(1);
                    //Console.WriteLine("{0}, {1}", xDim, yDim);
                    for (int y = 0; y <= yDim; y++)
                    {
                        for (int x = 0; x <= xDim; x++)
                        {
                            string locName = "*";

                            if (loc[x, y].locationName != null || loc[x, y].monsterID != 0)
                            {
                                //locName = (loc[x, y].locationName).Substring(1,1);
                                locName = "+";
                            }
                            if (x == playerX && y == playerY)
                            {
                                locName = "X";
                            }
                            await message.Channel.SendMessageAsync(locName);
                        }
                        await message.Channel.SendMessageAsync("");
                    }
                }

            }*/


    }
}