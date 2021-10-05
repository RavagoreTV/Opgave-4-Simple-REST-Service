using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opgave_1_Csharp;

namespace Opgave_4_Simple_REST_Service.Mangers
{
    public class FootballplayerManger
    {
        private static List<FootballPlayer> footballPlayers = new List<FootballPlayer>()
        {
            new FootballPlayer {Name = "Anders", Price = 300000, ShirtNumber = 10, Id = 1},
            new FootballPlayer {Name = "Benjamin", Price = 200000, ShirtNumber = 11, Id = 2},
            new FootballPlayer {Name = "Morten", Price = 500000, ShirtNumber = 12, Id = 3}
        };

        public List<FootballPlayer> GetAll(string substring)
        {
            List<FootballPlayer> result = new List<FootballPlayer>();
            if(substring != null)
            {
                result = result.FindAll(footballPlayers => footballPlayers.Name.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }
		public FootballPlayer GetById(int id)
		{
			return footballPlayers.Find(item => item.Id == id);
		}

		public FootballPlayer Add(FootballPlayer newPlayer)
		{
			newPlayer.Id++;
			footballPlayers.Add(newPlayer);
			return newPlayer;
		}

		public FootballPlayer Delete(int id)
		{
			FootballPlayer player = footballPlayers.Find(player1 => player1.Id == id);
			if (player == null) return null;
			footballPlayers.Remove(player);
			return player;
		}

		public FootballPlayer Update(int id, FootballPlayer updates)
		{
			FootballPlayer player = footballPlayers.Find(player1 => player1.Id == id);
			if (player == null) return null;
			player.Name = updates.Name;
			player.Price = updates.Price;
			player.ShirtNumber = updates.ShirtNumber;
			return player;
		}
	}
}
