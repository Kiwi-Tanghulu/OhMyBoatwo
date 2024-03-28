[System.Serializable]
public struct OptOption<T>
{
	public T PositiveOption;
    public T NegativeOption;

    public T GetOption(bool decision) => decision ? PositiveOption : NegativeOption;
}
