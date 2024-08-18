namespace Game.Abilities
{
    public interface IAbility
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string PrefabAddress { get; set; }
        AbilitySpawnLocation SpawnLocation { get; set; }
    }
}