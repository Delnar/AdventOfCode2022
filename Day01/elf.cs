public class Elf
{
    public int Id { get; set; } = -1;
    public List<int> Calories { get; set; } = new();
    public int TotalCalories { get => Calories.Sum(); }

    public Elf(int id)  { Id = id; }

    public void AddCalories(int calories) { Calories.Add(calories); }
}













