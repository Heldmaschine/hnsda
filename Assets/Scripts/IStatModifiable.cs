
public interface IStatModifiable
{
    float StatModifierValue { get; }

    void AddModifier(Modifier mod);
    void ClearModifiers();
    void UpdateModifiers();
}
