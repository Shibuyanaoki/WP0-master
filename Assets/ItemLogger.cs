using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemLogger
{
    static List<string> parts = new List<string>();

    //���X�g���̐���int�ŏ����o����
    //if�����Ŏg����
    public static int Count => parts.Count;

    public static bool Contains(string CheckStarPieceID)
    {
        return parts.Contains(CheckStarPieceID);
    }

    public static void Clear()
    {
        // �A�C�e�������N���A
        parts.Clear();
    }

    public static void Add(string GetStarPieceID)
    {
        if (Contains(GetStarPieceID))
        {
            //�擾��Ԃ͒ǉ�����^�C�~���O�ł��`�F�b�N!
            return;
        }
        // //�Q�b�g�����A�C�e�����L�^
        parts.Add(GetStarPieceID);
        Debug.Log(parts.Count);

    }
}
