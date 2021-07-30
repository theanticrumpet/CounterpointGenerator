﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace CounterpointGenerator
{
    public class MelodyLine
    {
        public List<Note> AMelodyLine { get; set; }


        public Note FirstNote {
            get
            {
                return this.AMelodyLine[0];
            }
        }

        public void RemoveFirstNote()
        {
            this.AMelodyLine.RemoveAt(0);
        }

        /**
         * Takes in a note.
         * Prepends it to the melody line (making it the new first note)
         * Returns the new melodyLine.
         */

        public void Prepend(Note firstCounterNote)
        {
            this.AMelodyLine.Insert(0, firstCounterNote);
        }

        public MelodyLine()
        {
            this.AMelodyLine = new List<Note>();
        }

        public MelodyLine(string cantus)
        {
            List<Note> InputCantus = new List<Note>();
            List<string> CantusString = cantus.Split(' ').ToList();
            foreach (var item in CantusString)
            {
                var newInputCantus = new Note(item);
                InputCantus.Add(newInputCantus);
            }
            this.AMelodyLine = InputCantus;
        }
    }
            
        
        
}
