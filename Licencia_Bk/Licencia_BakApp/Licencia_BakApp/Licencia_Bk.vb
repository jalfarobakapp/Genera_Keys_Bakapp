Imports System.Security.Cryptography

Public Class Licencia_Bk




    Function Fx_Genera_Licencia_BakApp(ByVal _RutEmpresa As String, _
                                       ByVal _FechaCaduca As Date, _
                                       ByVal _CantLicencias As Integer) As String()

        Dim _Llave1, _Llave2, _Llave3, _Llave4 As String

        _Llave1 = Encripta_md5(_RutEmpresa)
        _Llave2 = Encripta_md5(Format(_FechaCaduca, "yyyyMMdd"))
        _Llave3 = Encripta_md5(_CantLicencias)
        _Llave4 = Encripta_md5(_Llave1 & _Llave2 & _Llave3)

        Dim Licencia(3) As String

        Licencia(0) = _Llave1
        Licencia(1) = _Llave2
        Licencia(2) = _Llave3
        Licencia(3) = _Llave4

        Return Licencia


    End Function



    Private Function Encripta_md5(ByVal TextoAEncriptar As String) As String
        Dim vlo_MD5 As New MD5CryptoServiceProvider
        Dim vlby_Byte(), vlby_Hash() As Byte
        Dim vls_TextoEncriptado As String = ""

        'Convierte texto a encriptar a Bytes
        vlby_Byte = System.Text.Encoding.UTF8.GetBytes(TextoAEncriptar)

        'Aplicación del algoritmo hash
        vlby_Hash = vlo_MD5.ComputeHash(vlby_Byte)

        'Convierte la matriz de byte en una cadena
        For Each vlby_Aux As Byte In vlby_Hash
            vls_TextoEncriptado += vlby_Aux.ToString("x2")
        Next

        'Retorno de función
        Return vls_TextoEncriptado
    End Function

End Class
