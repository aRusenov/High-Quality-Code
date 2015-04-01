namespace RPG.Contracts
{
    public interface IItem
    {
        string Name { get; }

        int AttackPoints { get; }

        int DefensePoints { get; }
    }
}
