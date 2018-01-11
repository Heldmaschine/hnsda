class RPGEnemy: RPGStatCollection
{
    protected override void ConfigureStats()
    {
        var life = CreateOrGetStat<RPGVital>(RPGStatType.Life);
        life.StatBaseValue = 64;

    }
}
