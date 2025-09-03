using UnityEngine;

public class MatchChildLayerWithParent : MonoBehaviour
{
   private void Start()
    {
        // Lấy SpriteRenderer của đối tượng cha
        SpriteRenderer parentSpriteRenderer = GetComponent<SpriteRenderer>();

        if (parentSpriteRenderer != null)
        {
            // Gọi hàm để đặt sortingOrder của tất cả các đối tượng con
            SetSortingOrderRecursively(transform, parentSpriteRenderer.sortingLayerName);
        }
    }

    private void SetSortingOrderRecursively(Transform parent, string sortingLayer)
    {
        // Lặp qua tất cả các đối tượng con
        foreach (Transform child in parent)
        {
            // Lấy SpriteRenderer của đối tượng con
            SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();

            if (childSpriteRenderer != null)
            {
                // Đặt sortingOrder của đối tượng con giống với cha
                childSpriteRenderer.sortingLayerName = sortingLayer;
            }
            // Gọi hàm này đệ quy để đặt sortingOrder cho tất cả các đối tượng con của đối tượng hiện tại
            SetSortingOrderRecursively(child, sortingLayer);
        }
    }
}
//WARNING: HÀM NÀY LÀ ĐỂ ĐỒNG BỘ HÓA SORTINGLAYER CỦA CHILDREN VỚI PARENT CỦA NÓ, NẾU CÓ QUÁ NHIỀU CHILDREN, HÀM NÀY SẼ BỊ LAGGGGGGGGGGGGGGGG