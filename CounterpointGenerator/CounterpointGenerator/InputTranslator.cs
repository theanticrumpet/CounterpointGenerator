using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CounterpointGenerator
{
    /**
     * implementation of the layer that translates user input to intermediate representation.
     */
    public class InputTranslator : IInputTranslator
    {
        public InputTranslator()
        {
        }

        private void MelodyInvalid()
        {
            Console.WriteLine("Melody line input not valid");
            Console.WriteLine("Expected \"int pitch space double duration\" separated by commas!");
            Console.WriteLine("Insert a MelodyLine: ");
        }

        public Task<IInput> GetInput()
        {
            // Melody Line input
            Console.WriteLine("Input Acceptor: ");
            Console.WriteLine("Insert a MelodyLine: ");
            // Input expected to be something like "0 16, 0 16, 0 16"
            // (int space double comma space)* (int space double)
            bool checkMelody = true;
            List<Note> inputList = new List<Note>();
            while (checkMelody)
            {
                inputList.Clear();
                string melodyInput = Console.ReadLine();
                string[] outerSplit = melodyInput.Split(", ");

                if (outerSplit.Length == 1)
                {
                    MelodyInvalid();
                }
                else
                {
                    foreach (string s in outerSplit)
                    {
                        string[] innerSplit = s.Split(' ');

                        if (innerSplit.Length != 2)
                        {
                            MelodyInvalid();
                            break;
                        }
                        if (!int.TryParse(innerSplit[0], out int newPitch))
                        {
                            MelodyInvalid();
                            break;
                        }
                        if (!Double.TryParse(innerSplit[1], out double newDuration))
                        {
                            MelodyInvalid();
                            break;
                        }

                        inputList.Add(new Note(newPitch, newDuration));

                        if (inputList.Count == outerSplit.Length)
                        {
                            checkMelody = false;
                        }
                    }
                }
            }


            /*
            string InputString = Console.ReadLine();
            
            List<Note> InputList = new List<Note>();
            foreach(string s in InputString.Split(' '))
            {
                // TODO: Change when input changes drastically
                InputList.Add(new Note(int.Parse(s)));
            }
            */

            // Generation time input
            Console.WriteLine("Insert a prefered generating duration(in seconds): ");
            double userPreference = 0;
            bool checkTime = true;
            while (checkTime)
            {
                string inputPreference = Console.ReadLine();
                if (inputPreference == "")
                {
                    // Catch this first as it does weird things with TryParse
                    userPreference = Constants.DEFAULT_TIME_LIMIT;
                    checkTime = false;
                }
                else if (Double.TryParse(inputPreference, out userPreference))
                {
                    // TryParse sets the out parameter on check
                    // Only returns true if a double was successfully parsed
                    checkTime = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid double for time in seconds! Try again!");
                }
            }

            var input = new Input(new MelodyLine(inputList), userPreference);
            Console.WriteLine(input.ToString());
            return Task.FromResult<IInput>(input);
        }

    }
}