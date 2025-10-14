using System.ComponentModel.Design;

namespace BackTracking;

public class FindWordExists
{
    public bool Exist(char[][] board, string word) {
        int rows = board.Length;
        int cols = board[0].Length;

        for(int r = 0; r < rows;r++){
            for(int c = 0;c < cols;c++){
                if(BackTrack(r,c,0,board,word)){
                    return true;
                }
            }
        }

        return false;
    }

    private bool BackTrack(int r, int c, int i, char[][] board,string word){
        if(i == word.Length) return false;

        if(r < 0 ||r >= board.Length || c < 0 || c >= board[0].Length
           || board[r][c] != word[i]) return false;

        var temp = board[r][c];
        board[r][c] = '#';
        var res =
            BackTrack(r+1,c,i+1,board,word) ||
            BackTrack(r-1,c,i+1,board,word) ||
            BackTrack(r,c+1,i+1,board,word) ||
            BackTrack(r,c-1,i+1,board,word);

        board[r][c] = temp;

        return res;
    }
}