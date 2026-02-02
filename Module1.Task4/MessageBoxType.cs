namespace Module1.Task4;

[Flags]
public enum MessageBoxType : uint
{
    Ok = 0x00000000,
    OkCancel = 0x00000001,
    YesNo = 0x00000004,

    IconError = 0x00000010,
    IconQuestion = 0x00000020,
    IconWarning = 0x00000030,
    IconInformation = 0x00000040
}
