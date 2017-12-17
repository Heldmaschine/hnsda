
public interface IIStatModifiable
{
    float StatModifierValue { get; }

    void AddModifier(Modifier mod);
    void ClearModifiers();
    void UpdateModifiers();
}
