namespace LeetCode;
public class MinimumNumberEveryone
{
    public static int MinMovesToSeat(int[] seats, int[] students)
    {
        Array.Sort(seats);
        Array.Sort(students);

        int moves = 0;

        for (int i = 0; i < seats.Length; i++)
        {
            int seatPosition = seats[i];
            int studentPosition = students[i];
            moves += Math.Abs(seatPosition - studentPosition);
        }
        return moves;
    }
}