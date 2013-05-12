using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScoreboard
{
    class ScoreboardTestHelper:Hangman.Scoreboard
    {
        private string[] inputs = new string[10];

        private int currentInput = 0;

        public ScoreboardTestHelper()
        {
            this.highScoreList = new List<KeyValuePair<String, int>>();
        }
    }
}
