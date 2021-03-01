using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

 //参考サイト　https://qiita.com/OnederAppli/items/06795254652db0492d32

public class EncryptManager : MonoBehaviour {
    void Start() {
        /*// 保存データクラスをインスタンス化
        var userData = new UserData() { name = "HOGE", age = 20 };
        // クラスをJSON文字列に変換
        string json = JsonUtility.ToJson(userData);
        // byte配列に変換
        byte[] arr = System.Text.Encoding.UTF8.GetBytes(json);

        // AES暗号化サンプル処理
        AesEncryptSample(arr);

        // XOR暗号化サンプル処理
        XorEncrypt(arr);
        */
    }

    /// <summary>
    /// AES暗号化サンプル
    /// </summary>
    public static byte[] AesEncryptSample (byte[] arr) {
        // AES設定値
        //===================================
        int aesKeySize = 128;
        int aesBlockSize = 128;
        string aesIv = "1234567890123456";
        string aesKey = "1234567890123456";
        //===================================

        // AES暗号化
        byte[] arrEncrypted = AesEncrypt(arr, aesKeySize, aesBlockSize, aesIv, aesKey);
        /*
        // ファイル書き込み
        string path = System.IO.Path.Combine(Application.temporaryCachePath, "UserDataAES");
        System.IO.File.WriteAllBytes(path, arrEncrypted);

        // ファイル読み込み
        byte[] arrRead = System.IO.File.ReadAllBytes(path);

        // 復号化
        byte[] arrDecrypt = AesDecrypt(arrRead, aesKeySize, aesBlockSize, aesIv, aesKey);

        // byte配列を文字列に変換
        string decryptStr = System.Text.Encoding.UTF8.GetString(arrDecrypt);
        */
        Debug.Log("AES : " + arrEncrypted);
        return arrEncrypted;
    }

    /// <summary>
    /// XORサンプル
    /// </summary>
    public static byte[] XorEncrypt (byte[] arr) {
        // 暗号化文字列
        string keyString = "123456789";

        // 暗号化XOR
        byte[] keyArr = System.Text.Encoding.UTF8.GetBytes(keyString);
        byte[] arrEncrypted = Xor(arr, keyArr);
        
        /*
        // ファイル書き込み
        string path = System.IO.Path.Combine(Application.temporaryCachePath, "UserDataXOR");
        System.IO.File.WriteAllBytes(path, arrEncrypted);

        // ファイル読み込み
        byte[] arrRead = System.IO.File.ReadAllBytes(path);

        // 複合化XOR
        byte[] arrDecrypt = Xor(arrRead, keyArr);
        

        // byte配列を文字列に変換
        string decryptStr = System.Text.Encoding.UTF8.GetString(arrDecrypt);
        */

        Debug.Log("XOR : " + arrEncrypted);

        //仮置き
        return　arrEncrypted;
    }



    /// <summary>
    /// AES暗号化
    /// </summary>
    public static byte[] AesEncrypt (byte[] byteText, int aesKeySize, int aesBlockSize, string aesIv, string aesKey) {
        // AESマネージャー取得
        var aes = GetAesManager(aesKeySize, aesBlockSize, aesIv, aesKey);
        // 暗号化
        byte[] encryptText = aes.CreateEncryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return encryptText;
    }

    /// <summary>
    /// AES復号化
    /// </summary>
    public static byte[] AesDecrypt (byte[] byteText, int aesKeySize, int aesBlockSize, string aesIv, string aesKey) {
        // AESマネージャー取得
        var aes = GetAesManager(aesKeySize, aesBlockSize, aesIv, aesKey);
        // 復号化
        byte[] decryptText = aes.CreateDecryptor().TransformFinalBlock(byteText, 0, byteText.Length);

        return decryptText;
    }

    /// <summary>
    /// AesManagedを取得
    /// </summary>
    /// <param name="keySize">暗号化鍵の長さ</param>
    /// <param name="blockSize">ブロックサイズ</param>
    /// <param name="iv">初期化ベクトル(半角X文字（8bit * X = [keySize]bit))</param>
    /// <param name="key">暗号化鍵 (半X文字（8bit * X文字 = [keySize]bit）)</param>
    public static AesManaged GetAesManager (int keySize, int blockSize, string iv, string key) {
        AesManaged aes = new AesManaged();
        aes.KeySize = keySize;
        aes.BlockSize = blockSize;
        aes.Mode = CipherMode.CBC;
        aes.IV = Encoding.UTF8.GetBytes(iv);
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.Padding = PaddingMode.PKCS7;
        return aes;
    }


    /// <summary>
    /// XOR
    /// </summary>
    public static byte[] Xor(byte[] a, byte[] b){
        int i=0;
        int j=0;
        for (i=0 ; i<a.Length ; i++) 
        {
            if (j < b.Length)
            {
                j++;
            } 
            else 
            {
                j = 1;
            }
            a[i] = (byte)(a[i] ^ b[j - 1]);
        }
        return a;
    }
}