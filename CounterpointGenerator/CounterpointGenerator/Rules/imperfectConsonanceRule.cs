namespace CounterpointGenerator {
    public class imperfectConsonanceRule: IRules {
        /**
         * Imperfect consonance includes second, major and minor third,
         * major and minor sixth, and seventh.
         * HOWEVER
         * The text also forbids augmented, diminished, and chromatic intervals
         * To save some hassle I'm just gonna bake that into here too
         *
         * 3, 4, 8, and 9 semitones for m/M 3rd, m/M 6th
         */

        //Includes one octave up or down
        private Set<int> imperfectIntervals = {-9, -8, -4, -3, 3, 4, 8, 9};

        public List<int> apply(List<int> possibilities, int currentNote){
            List<int> output = new List<int>();
            foreach (int n in possibilities) {
                // Add checking outside one octave range?
                if (imperfectIntervals.Contains(n - currentNote)){
                    //If the difference between not in possibilities n is equal to an imperfect interval
                    output.add(n);
                }
            }
            return output;
        }
    }
}