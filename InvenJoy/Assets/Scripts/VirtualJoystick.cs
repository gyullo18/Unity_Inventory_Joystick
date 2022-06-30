using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // 오브젝트에 터치(상호작용)와 관련된 기능들의 공간(라이브러리)

// 조이스틱 관련 스크립트
public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Header("민감도")]
    public float sensitivity = 1; // 조작 민감도

    [Header("이미지 변수")]
    private Image imageBackground; // 조이스틱 UI 중 배경 이미지 변수
    private Image imageController; // 조이스틱 UI 중 컨트롤러(핸들) 이미지 변수

    [Header("벡터")]
    private Vector2 touchPosition; // 조이스틱의 방향정보
    
    // [Header("프로퍼티")]
    // 실제 외부로 보낼 프로 퍼티 구축
    
    private void Awake() 
    {
        imageBackground = GetComponent<Image>();
        imageController = transform.GetChild(0).GetComponent<Image>();
        // transform.GetChild(0) = ?
    }

    // IPointerDownHandler 인터페이스를 부모로 상속받을 경우 구현해야되는 메서드
    // 해당 스크립트를 가지고 있는 오브젝트를 터치했을 때 메서드가 1회 실행.
    // Check Point : 터치 시작 시 1회 실행!
    public void OnPointerDown(PointerEventData eventData)
    {
        // DownHandler가 없으면 UpHandler가 작동되지 않음.
    }

    // IDragHandler 인터페이스를 부모로 상속받을 경우 구현해야되는 메서드
    // 해당 스크립트를 가지고 있는 오브젝트를 터치 상태에서 드래그했을 때 메서드가 
    // 매 프레임마다 실행
    // Check Point : 터치 후 드래그 상태일 때 매 프레임 실행!
    public void OnDrag(PointerEventData eventData)
    {
        // 터치 포지션 초기화
        touchPosition = Vector2.zero;

        // 조이스틱의 위치가 어디에 있든 동일한 값을 연산하기 위해
        // 'touchPosition'의 위치 값은 이미지의 현재 위치를 기준으로
        // 얼마나 떨어져 있는지에 따라 다르게 나옴.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(imageBackground.rectTransform, 
                            eventData.position, eventData.pressEventCamera, out touchPosition);
        // RectTransformUtility.메서드(rect(범위를 넘어서면 인식하지 않도록), Vector2(터치한 지점의 위치값), 
        // 카메라, out Vector2) - bool형식 메서드
        // 
    }

    // IPointerUpHandler 인터페이스를 부모로 상속받을 경우 구현해야되는 메서드
    // 해당 스크립트를 가지고 있는 오브젝트를 터치 후 떼었을 때 메서드가 1회 실행
    // Check Point : 터치 종료 시 1회 실행!
    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
