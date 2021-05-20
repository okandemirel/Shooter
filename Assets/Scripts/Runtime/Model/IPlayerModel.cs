using Runtime.Data.ValueObject;
using Runtime.Key;

namespace Runtime.Model
{
    public interface IPlayerModel
    {
        int KilledEnemyCount { get; set; }
        PlayerVO PlayerVo { get; set; }

        LevelStartPlayerDataHolderParams LoadPlayerData();
    }
}