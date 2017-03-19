static class Dice
{
    public static int max(int dice1, int dice2)
    {
        return (dice1 > dice2 ? dice1 : dice2);
    }

    public static int min(int dice1, int dice2)
    {
        return (dice1 < dice2 ? dice1 : dice2);
    }

    public static int sum(int dice1, int dice2)
    {
        return (dice1 + dice2);
    }
}
