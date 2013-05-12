using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestScoreboard
{
    class ScoreboardTestHelper:Hangman.Scoreboard
    {
        private string[] inputs = new string[] { "Player1", "Player2", "Player3",
            "Player4", "Player5", "Player6", "Player7", "Player8"};

        public string[] Inputs
        {
            get { return inputs; }
            set { inputs = value; }
        }

        private int currentInput = 0;

        public ScoreboardTestHelper()
        {
            this.highScoreList = new List<KeyValuePair<String, int>>();
        }

        protected override string GetName()
        {
            currentInput++;
            if (this.currentInput >= this.inputs.Length)
            {
                this.currentInput = this.currentInput % this.inputs.Length;
            }
         
            return this.inputs[currentInput];
        }
    }
}
