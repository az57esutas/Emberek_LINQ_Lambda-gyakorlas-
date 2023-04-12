using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek_LINQ
{
	class Ember
	{
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public int Eletkor { get; set; }
        public string Iranyitoszam { get; set; }
        public string Varos { get; set; }
        public int Fizetes { get; set; }

		public override string ToString()
		{
			return string.Format("{0} {1}\t{2} év\t{3}\t{4}\t{5} Ft", 
				this.Vezeteknev,
				this.Keresztnev,
				this.Eletkor,
				this.Iranyitoszam,
				this.Varos,
				this.Fizetes);
		}
	}
}
