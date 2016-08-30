using System.Collections.Generic;
using System.Linq;
using System;

namespace msdemo
{
    //This implementation works just for note sets where each next note
    //is at least twice as big as previous
    public class Change
    {
        private static IEnumerable<int> _availableNotes;
        public Change (IEnumerable<int> availableNotes) {
            checkAvailableNotes(availableNotes);
            _availableNotes = availableNotes.OrderByDescending(x=>x);
        }

        private void checkAvailableNotes(IEnumerable<int> availableNotes)
        {
            if(availableNotes.Count() < 1) throw new ArgumentException("At least one note is needed.");
            availableNotes = availableNotes.OrderByDescending(x=>x);
            int? previousnote = null;

            foreach (var currentnote in availableNotes)
            {
                if(currentnote < 1) throw new ArgumentException("Each note has to have value greater than 0.");
                if(previousnote==null)
                {
                    previousnote = currentnote;
                    continue;
                }
                if(previousnote < currentnote * 2) throw new ArgumentException("Each note sorted by value needs to be at least twice as big as previous.");
                previousnote = currentnote;
            }
        }
        public int MakeChange(int amount)
        {
            if(amount < 0) throw new ArgumentException("Negative amounts can not be changed.");
            var remainingAmount = amount;
            int notesCount = 0;
            foreach(int note in _availableNotes)
            {
                    int currentnoteCount = remainingAmount / note;
                    remainingAmount -= note * currentnoteCount;
                    notesCount += currentnoteCount;
            }
            if (remainingAmount > 0) throw new ArgumentException($"There are no suitable notes to cover the whole amount. It is possible to use {notesCount} bills and it remains amount {remainingAmount} which can not be covered by current notes.");
            return notesCount;
        }
    }
}