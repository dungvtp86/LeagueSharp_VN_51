using System;
using System.Diagnostics.CodeAnalysis;
using LeagueSharp;
using LeagueSharp.Common;

namespace Yasuo
{
    public class YasuoLoader
    {
        /// <summary>
        ///     Yasuo Loader
        /// </summary>
        /// <param name="args">LeagueSharp.Loader common invoker arguments</param>
        private static void Main(string[] args)
        {
            // => Invoker
            if (args != null)
            {
                CustomEvents.Game.OnGameLoad += Game_OnGameLoad; // => On Game Loads
            }
        }

        /// <summary>
        ///     On Game Load
        /// </summary>
        /// <param name="args">System EventArgs</param>
        [SuppressMessage("ReSharper", "ObjectCreationAsStatement")]
        private static void Game_OnGameLoad(EventArgs args)
        {
            // => Champion Check
            if (!ObjectManager.Player.ChampionName.Equals("Yasuo"))
            {
                return;
            }

            // => Set Values
            Yasuo.Player = ObjectManager.Player; // => Player Instance
            Yasuo.Menu = new YasuoMenu(); // => Menu Instance
            Yasuo.Game = new YasuoGame(Yasuo.Player, Yasuo.Menu); // => Game Instance

            // => Class Caller
            new YasuoSpells(); // => Spell Initialization

            // => Events
            Game.OnGameUpdate += Yasuo.Game.OnGameUpdate; // => On Game Update

            // => Notify
            Game.PrintChat(
                "<font color=\"#be4cb7\"><b>L33T</b></font> | <font color=\"#1762a1\">Yasuo</font> the Unforgiven, loaded.");
        }
    }
}