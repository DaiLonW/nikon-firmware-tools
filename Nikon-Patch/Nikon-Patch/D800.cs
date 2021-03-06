﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Text;


namespace Nikon_Patch
{
    class D800_0101 : Firmware
    {
        Patch[] patch_mov_len = {
              new Patch(1, 0x225B0, new byte[] { 0xE4, 0x01 }, new byte[] { 0xE0, 0x01 }), // mov 1/3
              new Patch(1, 0x2275c, new byte[] { 0xE4, 0x02 }, new byte[] { 0xE0, 0x02 }), // mov 2/3
              new Patch(1, 0x238EE, new byte[] { 0xE4, 0x0A }, new byte[] { 0xE0, 0x0A }), // mov 3/3
                                 };

        public D800_0101()
        {
            p = new Package();
            Model = "D800";
            Version = "1.01";

            //Patches.Add(new PatchSet(PatchLevel.Beta, "Remove Time Based Video Restrictions", patch_mov_len));
        }
    }

    class D800_0102 : Firmware
    {
        Patch[] patch_1080_36mbps = {
            new Patch(1, 0x21E36, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E3C, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E4A, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E68, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E76, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EB4, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21EC2, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_54mbps = {
            new Patch(1, 0x21E36, new byte[] { 0x01 } , new byte[] { 0x03 } ),
            new Patch(1, 0x21E3C, new byte[] { 0x01 } , new byte[] { 0x03 } ),
            new Patch(1, 0x21E4A, new byte[] { 0x00, 0xB7, 0x1B } , new byte[] { 0x01, 0x6E, 0x36 } ),
            new Patch(1, 0x21E50, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62, new byte[] { 0x01 } , new byte[] { 0x03 } ),
            new Patch(1, 0x21E68, new byte[] { 0x01 } , new byte[] { 0x03 } ),
            new Patch(1, 0x21E76, new byte[] { 0x00, 0xB7, 0x1B } , new byte[] { 0x01, 0x6E, 0x36 } ),
            new Patch(1, 0x21E7C, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE, new byte[] { 0x01 } , new byte[] { 0x03 } ),
            new Patch(1, 0x21EB4, new byte[] { 0x01 } , new byte[] { 0x03 } ),
            new Patch(1, 0x21EC2, new byte[] { 0x00, 0xB7, 0x1B } , new byte[] { 0x01, 0x6E, 0x36 } ),
            new Patch(1, 0x21EC8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_64mbps = {
            new Patch(1, 0x21E36, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E3C, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E4A, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E68, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E76, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21EB4, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21EC2, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };


        public D800_0102()
        {
            p = new Package();
            Model = "D800";
            Version = "1.02";

            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 36mbps Bit-rate NQ old HQ", patch_1080_36mbps, patch_1080_54mbps, patch_1080_64mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 54mbps Bit-rate NQ old HQ", patch_1080_54mbps, patch_1080_36mbps, patch_1080_64mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 64mbps Bit-rate NQ old HQ", patch_1080_64mbps, patch_1080_36mbps, patch_1080_54mbps));

        }
    }


    class D800_0110 : Firmware
    {
        Patch[] patch_1080_36mbps = {
            new Patch(1, 0x21E36 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E3C - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E4A - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E68 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E76 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EB4 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21EC2 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_54mbps = {
            new Patch(1, 0x21E36 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E3C - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E4A - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E68 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E76 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EB4 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21EC2 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_64mbps = {
            new Patch(1, 0x21E36 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E3C - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E4A - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E68 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E76 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21EB4 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21EC2 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_64_36_mbps = {
            new Patch(1, 0x21E36 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E3C - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E4A - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E68 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E76 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21EB4 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21EC2 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x02, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_Language_Fix = {
            new Patch(1, 0x3EA1A6, new byte[] { 0xE2, 0x08 }, new byte[] { 0xE0, 0x08 }),
            new Patch(1, 0x3EEE76, new byte[] { 0xE2, 0x11 }, new byte[] { 0xE0, 0x11 }),
                          };

        public D800_0110()
        {
            p = new Package();
            Model = "D800";
            Version = "1.10";

            Patches.Add(new PatchSet(PatchLevel.Alpha, "Multi-Language Support", patch_Language_Fix));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 36mbps Bit-rate NQ old HQ", patch_1080_36mbps, patch_1080_54mbps, patch_1080_64mbps, patch_1080_64_36_mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 54mbps Bit-rate NQ old HQ", patch_1080_54mbps, patch_1080_36mbps, patch_1080_64mbps, patch_1080_64_36_mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 64mbps Bit-rate NQ old HQ", patch_1080_64mbps, patch_1080_36mbps, patch_1080_54mbps, patch_1080_64_36_mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 64mbps, NQ 36mbps", patch_1080_64_36_mbps, patch_1080_64mbps, patch_1080_36mbps, patch_1080_54mbps));

        }
    }



    /* D800E ---------------------------------------------------------------*/

    class D800E_0101 : Firmware
    {

        public D800E_0101()
        {
            p = new Package();
            Model = "D800E";
            Version = "1.01";
        }
    }

    class D800E_0102 : Firmware
    {
        Patch[] patch_1080_36mbps = {
            new Patch(1, 0x21E36, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E3C, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E4A, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E68, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E76, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EB4, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21EC2, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_54mbps = {
            new Patch(1, 0x21E36, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E3C, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E4A, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E68, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E76, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EB4, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21EC2, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_64mbps = {
            new Patch(1, 0x21E36, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E3C, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E4A, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E68, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E76, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21EB4, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21EC2, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };


        public D800E_0102()
        {
            p = new Package();
            Model = "D800E";
            Version = "1.02";

            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 36mbps Bit-rate NQ old HQ", patch_1080_36mbps, patch_1080_54mbps, patch_1080_64mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 54mbps Bit-rate NQ old HQ", patch_1080_54mbps, patch_1080_36mbps, patch_1080_64mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 64mbps Bit-rate NQ old HQ", patch_1080_64mbps, patch_1080_36mbps, patch_1080_54mbps));
        }
    }

    class D800E_0110 : Firmware
    {
        Patch[] patch_1080_36mbps = {
            new Patch(1, 0x21E36 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E3C - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E4A - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E68 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E76 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x02, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EB4 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x02, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21EC2 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_54mbps = {
            new Patch(1, 0x21E36 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E3C - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E4A - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E68 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21E76 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EB4 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x31, 0x2D, 0x00 } ),
            new Patch(1, 0x21EC2 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

        Patch[] patch_1080_64mbps = {
            new Patch(1, 0x21E36 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E3C - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E4A - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E50 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21E62 - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21E68 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21E76 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21E7C - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00 } ),

            new Patch(1, 0x21EAE - 8, new byte[] { 0x01, 0x6E, 0x36, 0x00 } , new byte[] { 0x03, 0xd0, 0x90, 0x00 } ),
            new Patch(1, 0x21EB4 - 8, new byte[] { 0x01, 0x31, 0x2D, 0x00 } , new byte[] { 0x03, 0x93, 0x87, 0x00 } ),
            new Patch(1, 0x21EC2 - 8, new byte[] { 0x00, 0xB7, 0x1B, 0x00 } , new byte[] { 0x01, 0x6E, 0x36, 0x00 } ),
            new Patch(1, 0x21EC8 - 8, new byte[] { 0x00, 0x98, 0x96, 0x80 } , new byte[] { 0x01, 0x31, 0x2D, 0x00} ),
                                  };

 
        public D800E_0110()
        {
            p = new Package();
            Model = "D800E";
            Version = "1.10";


            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 36mbps Bit-rate NQ old HQ", patch_1080_36mbps, patch_1080_54mbps, patch_1080_64mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 54mbps Bit-rate NQ old HQ", patch_1080_54mbps, patch_1080_36mbps, patch_1080_64mbps));
            Patches.Add(new PatchSet(PatchLevel.Released, "Video 1080 HQ 64mbps Bit-rate NQ old HQ", patch_1080_64mbps, patch_1080_36mbps, patch_1080_54mbps));

        }
    }

}
