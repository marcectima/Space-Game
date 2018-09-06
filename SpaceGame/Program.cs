﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting the conolse text color to green
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            // Creating the univers
            List<PlanetarySystem> universe = Utilities.OperationGenesis();

            // Creating trading goods and trade menus
            Goods[] tradingGoods = Utilities.CreateTradingGoods();
            string[] TradeMenu = Utilities.CreateTradeMenus(tradingGoods);
            // Game's Introduction
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(" \n" +
                "                                                                                                                         \n" +
                "                                  ______________________________________________________________                                                                                        \n" +
                "                                 |  ___________________________________________________________  |                                                                                      \n" +
                "                                 | |                                               __          | |                           \n" +
                "                                 | |           __                            __   |__|         | |                                \n" +
                "                                 | |        __|  |__                        |__|     __        | |                                     \n" +
                "                                 | |       |__    __|       __      __         __   |__|       | |                                       \n" +
                "                                 | |          |__|         /_/     /_/        |__|             | |                                       \n" +
                "                                 | |___________________________________________________________| |                                                                                       \n" +
                "                                 |_______________________________________________________________|                                     \n" +
                "                                                                                                                         \n" +
                "                                                          " + "Elliot Gaming \n" +
                "                                                                                                                         \n");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "\n" +
                "                                                   " + "Gabriel and Marc\n" +
                "\n" +
                "                                                       " + "Presents");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\n                                                                                                          " +
                "   " +
                "                                                                    /\\                       .           \n" +
                "         .                  .                           /  \\       .                           .         \n" +
                "                                                       /    \\                 .                          \n" +
                "                                                      /______\\                                    .      \n" +
                "                            .                        /        \\                     .                    \n" +
                "                                                    /          \\                                         \n" +
                "             .                                     /            \\            .                           \n" +
                "                                                  |              |                            .           \n" +
                "                                                  |______________|                                        \n" +
                "                                                 /                \\                                      \n" +
                "                            .                   /__________________\\         .                           \n" +
                "               .                               /|                  |\\                                    \n" +
                "                                              / |                  | \\                     .         .   \n" +
                "                                             /  |                  |  \\                                  \n" +
                "                            .               |   |                  |   |                                  \n" +
                "       .                                    |   |                  |   |           .                   .  \n" +
                "                                            |___|__________________|___|                                  \n" +
                "                              .                   |             |                                         \n" +
                "       .                                          |_____________|                           .             \n" +
                "                                                  _ _ _ _ _ _ _ _                                         \n" +
                "                                                 " + "   Space Trader \n" +
                "                                                  _ _ _ _ _ _ _ _ ");
            Console.ReadLine();
            Console.Clear();
            // Creating a new user.
            Player myPlayer = new Player();
            Console.Clear();

            // Opens action menu. This is where the game runs.
            ShowActionMenu(myPlayer, universe, tradingGoods, TradeMenu);
        }

        // Action menu
        private static void ShowActionMenu(Player myPlayer, List<PlanetarySystem> universe, Goods[] tradingGoods, string[] TradeMenu)
        {
            bool keepLooping = true;
            do
            {
                bool commandNotExecuted = true;
                do
                {
                    try
                    {
                        Console.Write("\nSelect from the following options:\n\n1. Status\n2. Trade\n3. Travel to...\n4. Refuel\n5. Change ship\n6. Quit game\n\n>>> ");
                        MenuSelection selection = new MenuSelection(Console.ReadLine().Trim());
                        if (Enumerable.Range(1, 6).Contains(selection.GetSelection()))
                        {
                            switch (selection.GetSelection())
                            {
                                case 1:
                                    myPlayer.ShowStatus();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Trade(tradingGoods, myPlayer, TradeMenu);
                                    break;
                                case 3:
                                    myPlayer.Travel(universe);
                                    break;
                                case 4:
                                    myPlayer.Refuel(true);
                                    break;
                                case 5:
                                    myPlayer.newShip(true);
                                    break;
                                case 6:
                                    Console.WriteLine("You chose to end the game.\n");
                                    Utilities.EndGameReport(myPlayer);
                                    keepLooping = false;
                                    break;
                            }
                            commandNotExecuted = false;
                        }
                        else
                        {
                            Console.Clear();
                            throw new Exception("\nInvalid Entry");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                } while (commandNotExecuted);
                Console.WriteLine("\nCommand successfully executed. Press Enter to Continue.");
                Console.ReadLine();
                Console.Clear();
            } while (keepLooping);
        }

        // Executes the trading decisions
        private static void Trade(Goods[] tradingGoods, Player myPlayer, string[] TradeMenu)
        {
            string buyMenu = TradeMenu[0];
            string sellMenu = TradeMenu[1];
            bool keepLooping = true;
            do
            {
                Console.Write("\nSelect from the following options:\n\n1. buy\n2. sell\n\n>>> ");
                MenuSelection tradeMode = new MenuSelection(Console.ReadLine().Trim());
                try
                {
                    if (tradeMode.GetSelection() == 1)
                    {
                        myPlayer.BuyGoods(buyMenu, tradingGoods);
                    }
                    else if (tradeMode.GetSelection() == 2)
                    {
                        myPlayer.SellGoods(sellMenu, tradingGoods);
                    }
                    else
                    {
                        throw new Exception("\nInvalid Entry");
                    }
                    keepLooping = false;
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                }
            } while (keepLooping);
        } 
    }
}