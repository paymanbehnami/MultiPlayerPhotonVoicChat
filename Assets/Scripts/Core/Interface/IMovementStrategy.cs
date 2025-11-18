using UnityEngine;

public interface IMovementStrategy
{
    void Move(CharacterController controller, PlayerSetting setting);
}
