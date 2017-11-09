
public interface IStatModifiable
{
    int StatModifierValue { get; }

    void AddModifier(Modifier mod);
    void ClearModifiers();
    void UpdateModifiers();
}
