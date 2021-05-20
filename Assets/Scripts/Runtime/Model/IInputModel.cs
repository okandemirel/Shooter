using Runtime.Data.ValueObject;
using Runtime.Key;

namespace Runtime.Model
{
    public interface IInputModel
    {
        InputVO InputVo { get; set; }

        LevelStartInputDataHolderParam LoadInputData();
    }
}