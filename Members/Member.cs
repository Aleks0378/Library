using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Members
{
    public class Member
    {
        public string Name { get; set; }
        public int TicketNumber { get; set; }

        public Member(string name, int ticketNumber)
        {
            Name = name;
            TicketNumber = ticketNumber;
        }

        public override string ToString()
        {
            return $"{Name} (Ticket #{TicketNumber})";
        }
    }
}
