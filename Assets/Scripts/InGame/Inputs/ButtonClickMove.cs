using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClickMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isPressed = false;
    public int valueToSend;
    public TankMovement tank;

    // Este método é chamado quando o botão é pressionado
    public void OnPointerDown(PointerEventData eventData)
    {
        tank.TruckMove(valueToSend);
    }

    // Este método é chamado quando o botão é solto
    public void OnPointerUp(PointerEventData eventData)
    {
        tank.TruckMove(0);
    }
}
