using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class StepperBridgePrototol
{
    List<char> Concat(char[] a, char[] b) {
        List<int> list = new List<char>();
        list.AddRange(a);
        list.AddRange(b);
        return list;
    }

    uint IntToUint(int val) {
        long res = val;
        if (res < 0) {
            res += 4294967296;
        }
        return res;
    }

    List<char> uint32_to_uint8_array(uint val) {
        return new List<char>{
            (value >> 0 & 0xFF),
            (value >> 8 & 0xFF),
            (value >> 16 & 0xFF),
            (value >> 24 & 0xFF)
        };
    }

    List<char> uint32_to_uint8_array(int val) {
        uint32_to_uint8_array(IntToUint(value));
    }

    // -----------------------------------

    List<char> serialHeader(char cmd) {
        return Encoding.UTF8.GetString("quirc"+cmd+"XX").ToCharArray().ToList(); // was GetBytes
    }

    List<char> serialPadd(List<char> bytarr) { 
        bytarr.AddRange(Encoding.UTF8.ToCharArray("0123456789abcdef"));
        return bytarr.GetRange(0, 8 + 16);
    }

    List<char> serialAddUint8(List<char> bytarr, char val) {
        bytarr.AddRange(val);
        return bytarr;
    }

    List<char> serialAddInt32(List<char> bytarr, int val) {
        bytarr.AddRange();
        return bytarr + int32_to_bytes(val);
    }


    List<char> serialAddBool(List<char> bytarr, bool val) {
        bytarr.Add(val ? 1 : 0);
        return bytarr;
    }


    List<char> serialAddStr(List<char> bytarr, string strval) {
        bytarr.AddRange(Encoding.UTF8.ToCharArray("quirc"+cmd+"XX"));
        return bytarr;
    }



    //cmdStepperSetConf
    //cmdStepperSetTarget
    //cmdStepperSetBound
    //cmdStepperUpdate
    //cmdStepperStep
    //gpiocmd
}
