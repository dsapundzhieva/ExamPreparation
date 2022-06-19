using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Roster = new List<Player>(capacity);
        }

        public List<Player> Roster { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (this.Roster.Count < this.Capacity)
            {
                this.Roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (this.Roster.Any(x => x.Name == name))
            {
                Player player = this.Roster.First(x => x.Name == name);
                this.Roster.Remove(player);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player player = this.Roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player player = this.Roster.FirstOrDefault(x => x.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] playerList = new Player[this.Roster.FindAll(x => x.Class == @class).Count];
            int idx = 0;

            foreach (var player in this.Roster)
            {
                if (player.Class == @class)
                {
                    playerList[idx] = player;
                    idx++;
                }
            }

            this.Roster.RemoveAll(p => p.Class == @class);
            return playerList;
        }

        public int Count => this.Roster.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in Roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
