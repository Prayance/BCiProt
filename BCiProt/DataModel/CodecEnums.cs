using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BCiProt.DataModel
{

    public enum Video_Codec
    {
        none,
        copy,
        _012v,
        //Uncompressed 4:2:2 10-bit
        _4xm,
        //4X Movie
        _8bps,
        //QuickTime 8BPS video
        a64_multi,
        //Multicolor charset for Commodore 64 (encoders: a64multi )
        a64_multi5,
        //Multicolor charset for Commodore 64, extended with 5th color (colram) (encoders: a64multi5 )
        aasc,
        //Autodesk RLE
        amv,
        //AMV Video
        anm,
        //Deluxe Paint Animation
        ansi,
        //ASCII/ANSI art
        asv1,
        //ASUS V1
        asv2,
        //ASUS V2
        aura,
        //Auravision AURA
        aura2,
        //Auravision Aura 2
        avrn,
        //Avid AVI Codec
        avrp,
        //Avid 1:1 10-bit RGB Packer
        avs,
        //AVS (Audio Video Standard) video
        avui,
        //Avid Meridien Uncompressed
        ayuv,
        //Uncompressed packed MS 4:4:4:4
        bethsoftvid,
        //Bethesda VID video
        bfi,
        //Brute Force & Ignorance
        binkvideo,
        //Bink video
        bintext,
        //Binary text
        bmp,
        //BMP (Windows and OS/2 bitmap)
        bmv_video,
        //Discworld II BMV video
        brender_pix,
        //BRender PIX image
        c93,
        //Interplay C93
        cavs,
        //Chinese AVS (Audio Video Standard) (AVS1-P2, JiZhun profile) (encoders: libxavs )
        cdgraphics,
        //CD Graphics video
        cdxl,
        //Commodore CDXL video
        cinepak,
        //Cinepak
        cljr,
        //Cirrus Logic AccuPak
        cllc,
        //Canopus Lossless Codec
        cmv,
        //Electronic Arts CMV video (decoders: eacmv )
        cpia,
        //CPiA video format
        cscd,
        //CamStudio (decoders: camstudio )
        cyuv,
        //Creative YUV (CYUV)
        dfa,
        //Chronomaster DFA
        dirac,
        //Dirac (decoders: dirac libschroedinger ) (encoders: libschroedinger )
        dnxhd,
        //VC3/DNxHD
        dpx,
        //DPX image
        dsicinvideo,
        //Delphine Software International CIN video
        dvvideo,
        //DV (Digital Video)
        dxa,
        //Feeble Files/ScummVM DXA
        dxtory,
        //Dxtory
        escape124,
        //Escape 124
        escape130,
        //Escape 130
        exr,
        //OpenEXR image
        ffv1,
        //FFmpeg video codec #1
        ffvhuff,
        //Huffyuv FFmpeg variant
        flashsv,
        //Flash Screen Video v1
        flashsv2,
        //Flash Screen Video v2
        flic,
        //Autodesk Animator Flic video
        flv1,
        //FLV / Sorenson Spark / Sorenson H.263 (Flash Video) (decoders: flv ) (encoders: flv )
        fraps,
        //Fraps
        frwu,
        //Forward Uncompressed
        g2m,
        //GoToMeeting
        gif,
        //GIF (Graphics Interchange Format)
        h261,
        //H.261
        h263,
        //H.263 / H.263-1996, H.263+ / H.263-1998 / H.263 version 2
        h263i,
        //Intel H.263
        h263p,
        //H.263+ / H.263-1998 / H.263 version 2
        h264,
        //H.264 / AVC / MPEG-4 AVC / MPEG-4 part 10 (encoders: libx264 libx264rgb )
        hevc,
        //H.265 / HEVC (High Efficiency Video Coding) (encoders: libx265 )
        huffyuv,
        //HuffYUV
        idcin,
        //id Quake II CIN video (decoders: idcinvideo )
        idf,
        //iCEDraw text
        iff_byterun1,
        //IFF ByteRun1 (decoders: iff )
        iff_ilbm,
        //IFF ILBM (decoders: iff )
        indeo2,
        //Intel Indeo 2
        indeo3,
        //Intel Indeo 3
        indeo4,
        //Intel Indeo Video Interactive 4
        indeo5,
        //Intel Indeo Video Interactive 5
        interplayvideo,
        //Interplay MVE video
        jpeg2000,
        //JPEG 2000 (decoders: j2k jpeg2000 libopenjpeg ) (encoders: j2k libopenjpeg )
        jpegls,
        //JPEG-LS
        jv,
        //Bitmap Brothers JV video
        kgv1,
        //Kega Game Video
        kmvc,
        //Karl Morton's video codec
        lagarith,
        //Lagarith lossless
        ljpeg,
        //Lossless JPEG
        loco,
        //LOCO
        mad,
        //Electronic Arts Madcow Video (decoders: eamad )
        mdec,
        //Sony PlayStation MDEC (Motion DECoder)
        mimic,
        //Mimic
        mjpeg,
        //Motion JPEG
        mjpegb,
        //Apple MJPEG-B
        mmvideo,
        //American Laser Games MM Video
        motionpixels,
        //Motion Pixels video
        mpeg1video,
        //MPEG-1 video
        mpeg2video,
        //MPEG-2 video (decoders: mpeg2video mpegvideo )
        mpeg4,
        //MPEG-4 part 2 (encoders: mpeg4 libxvid )
        mpegvideo_xvmc,
        //MPEG-1/2 video XvMC (X-Video Motion Compensation)
        msa1,
        //MS ATC Screen
        msmpeg4v1,
        //MPEG-4 part 2 Microsoft variant version 1
        msmpeg4v2,
        //MPEG-4 part 2 Microsoft variant version 2
        msmpeg4v3,
        //MPEG-4 part 2 Microsoft variant version 3 (decoders: msmpeg4 ) (encoders: msmpeg4 )
        msrle,
        //Microsoft RLE
        mss1,
        //MS Screen 1
        mss2,
        //MS Windows Media Video V9 Screen
        msvideo1,
        //Microsoft Video 1
        mszh,
        //LCL (LossLess Codec Library) MSZH
        mts2,
        //MS Expression Encoder Screen
        mvc1,
        //Silicon Graphics Motion Video Compressor 1
        mvc2,
        //Silicon Graphics Motion Video Compressor 2
        mxpeg,
        //Mobotix MxPEG video
        nuv,
        //NuppelVideo/RTJPEG
        paf_video,
        //Amazing Studio Packed Animation File Video
        pam,
        //PAM (Portable AnyMap) image
        pbm,
        //PBM (Portable BitMap) image
        pcx,
        //PC Paintbrush PCX image
        pgm,
        //PGM (Portable GrayMap) image
        pgmyuv,
        //PGMYUV (Portable GrayMap YUV) image
        pictor,
        //Pictor/PC Paint
        png,
        //PNG (Portable Network Graphics) image
        ppm,
        //PPM (Portable PixelMap) image
        prores,
        //Apple ProRes (iCodec Pro) (decoders: prores prores_lgpl ) (encoders: prores prores_aw prores_ks )
        ptx,
        //V.Flash PTX image
        qdraw,
        //Apple QuickDraw
        qpeg,
        //Q-team QPEG
        qtrle,
        //QuickTime Animation (RLE) video
        r10k,
        //AJA Kona 10-bit RGB Codec
        r210,
        //Uncompressed RGB 10-bit
        rawvideo,
        //raw video
        rl2,
        //RL2 video
        roq,
        //id RoQ video (decoders: roqvideo ) (encoders: roqvideo )
        rpza,
        //QuickTime video (RPZA)
        rv10,
        //RealVideo 1.0
        rv20,
        //RealVideo 1.0
        rv30,
        //RealVideo 3.0
        rv40,
        //RealVideo 4.0
        sanm,
        //LucasArts SMUSH video
        sgi,
        //SGI image
        sgirle,
        //SGI RLE 8-bit
        smackvideo,
        //Smacker video (decoders: smackvid )
        smc,
        //QuickTime Graphics (SMC)
        snow,
        //Snow
        sp5x,
        //Sunplus JPEG (SP5X)
        sunrast,
        //Sun Rasterfile image
        svq1,
        //Sorenson Vector Quantizer 1 / Sorenson Video 1 / SVQ1
        svq3,
        //Sorenson Vector Quantizer 3 / Sorenson Video 3 / SVQ3
        targa,
        //Truevision Targa image
        targa_y216,
        //Pinnacle TARGA CineWave YUV16
        tgq,
        //Electronic Arts TGQ video (decoders: eatgq )
        tgv,
        //Electronic Arts TGV video (decoders: eatgv )
        theora,
        //Theora (encoders: libtheora )
        thp,
        //Nintendo Gamecube THP video
        tiertexseqvideo,
        //Tiertex Limited SEQ video
        tiff,
        //TIFF image
        tmv,
        //8088flex TMV
        tqi,
        //Electronic Arts TQI video (decoders: eatqi )
        truemotion1,
        //Duck TrueMotion 1.0
        truemotion2,
        //Duck TrueMotion 2.0
        tscc,
        //TechSmith Screen Capture Codec (decoders: camtasia )
        tscc2,
        //TechSmith Screen Codec 2
        txd,
        //Renderware TXD (TeXture Dictionary) image
        ulti,
        //IBM UltiMotion (decoders: ultimotion )
        utvideo,
        //Ut Video
        v210,
        //Uncompressed 4:2:2 10-bit
        v210x,
        //
        v308,
        //Uncompressed packed 4:4:4
        v408,
        //Uncompressed packed QT 4:4:4:4
        v410,
        //Uncompressed 4:4:4 10-bit
        vb,
        //Beam Software VB
        vble,
        //VBLE Lossless Codec
        vc1,
        //SMPTE VC-1
        vc1image,
        //Windows Media Video 9 Image v2
        vcr1,
        //ATI VCR1
        vixl,
        //Miro VideoXL (decoders: xl )
        vmdvideo,
        //Sierra VMD video
        vmnc,
        //VMware Screen Codec / VMware Video
        vp3,
        //On2 VP3
        vp5,
        //On2 VP5
        vp6,
        //On2 VP6
        vp6a,
        //On2 VP6 (Flash version, with alpha channel)
        vp6f,
        //On2 VP6 (Flash version)
        vp8,
        //On2 VP8 (decoders: vp8 libvpx ) (encoders: libvpx )
        vp9,
        //Google VP9
        webp,
        //WebP
        wmv1,
        //Windows Media Video 7
        wmv2,
        //Windows Media Video 8
        wmv3,
        //Windows Media Video 9
        wmv3image,
        //Windows Media Video 9 Image
        wnv1,
        //Winnov WNV1
        ws_vqa,
        //Westwood Studios VQA (Vector Quantized Animation) video (decoders: vqavideo )
        xan_wc3,
        //Wing Commander III / Xan
        xan_wc4,
        //Wing Commander IV / Xxan
        xbin,
        //eXtended BINary text
        xbm,
        //XBM (X BitMap) image
        xface,
        //X-face image
        Xvid,
        xwd,
        //XWD (X Window Dump) image
        y41p,
        //Uncompressed YUV 4:1:1 12-bit
        yop,
        //Psygnosis YOP Video
        yuv4,
        //Uncompressed packed 4:2:0
        zerocodec,
        //ZeroCodec Lossless Video
        zlib,
        //LCL (LossLess Codec Library) ZLIB
        zmbv
        //Zip Motion Blocks Video
    }
    public enum Audio_Codec
    {
        none,
        //pass through - same as copy
        copy,
        //copy with no processing
        _8svx_exp,
        //8SVX exponential
        _8svx_fib,
        //8SVX fibonacci
        aac,
        //AAC (Advanced Audio Coding) (encoders: aac libvo_aacenc )
        aac_latm,
        //AAC LATM (Advanced Audio Coding LATM syntax)
        libvo_aacenc,
        // experimental aac codec for 7.1 (LC-AAC) - worst
        libfdk_aac,
        //LC-AAC - best
        libfaac,
        //HE-AAC - middle
        libaacplus,
        //HE-AAC
        ac3,
        //ATSC A/52A (AC-3) (encoders: ac3 ac3_fixed )
        adpcm_4xm,
        //ADPCM 4X Movie
        adpcm_adx,
        //SEGA CRI ADX ADPCM
        adpcm_afc,
        //ADPCM Nintendo Gamecube AFC
        adpcm_ct,
        //ADPCM Creative Technology
        adpcm_dtk,
        //ADPCM Nintendo Gamecube DTK
        adpcm_ea,
        //ADPCM Electronic Arts
        adpcm_ea_maxis_xa,
        //ADPCM Electronic Arts Maxis CDROM XA
        adpcm_ea_r1,
        //ADPCM Electronic Arts R1
        adpcm_ea_r2,
        //ADPCM Electronic Arts R2
        adpcm_ea_r3,
        //ADPCM Electronic Arts R3
        adpcm_ea_xas,
        //ADPCM Electronic Arts XAS
        adpcm_g722,
        //G.722 ADPCM (decoders: g722 ) (encoders: g722 )
        adpcm_g726,
        //G.726 ADPCM (decoders: g726 ) (encoders: g726 )
        adpcm_ima_amv,
        //ADPCM IMA AMV
        adpcm_ima_apc,
        //ADPCM IMA CRYO APC
        adpcm_ima_dk3,
        //ADPCM IMA Duck DK3
        adpcm_ima_dk4,
        //ADPCM IMA Duck DK4
        adpcm_ima_ea_eacs,
        //ADPCM IMA Electronic Arts EACS
        adpcm_ima_ea_sead,
        //ADPCM IMA Electronic Arts SEAD
        adpcm_ima_iss,
        //ADPCM IMA Funcom ISS
        adpcm_ima_oki,
        //ADPCM IMA Dialogic OKI
        adpcm_ima_qt,
        //ADPCM IMA QuickTime
        adpcm_ima_rad,
        //ADPCM IMA Radical
        adpcm_ima_smjpeg,
        //ADPCM IMA Loki SDL MJPEG
        adpcm_ima_wav,
        //ADPCM IMA WAV
        adpcm_ima_ws,
        //ADPCM IMA Westwood
        adpcm_ms,
        //ADPCM Microsoft
        adpcm_sbpro_2,
        //ADPCM Sound Blaster Pro 2-bit
        adpcm_sbpro_3,
        //ADPCM Sound Blaster Pro 2.6-bit
        adpcm_sbpro_4,
        //ADPCM Sound Blaster Pro 4-bit
        adpcm_swf,
        //ADPCM Shockwave Flash
        adpcm_thp,
        //ADPCM Nintendo Gamecube THP
        adpcm_xa,
        //ADPCM CDROM XA
        adpcm_yamaha,
        //ADPCM Yamaha
        alac,
        //ALAC (Apple Lossless Audio Codec)
        amr_nb,
        //AMR-NB (Adaptive Multi-Rate NarrowBand) (decoders: amrnb libopencore_amrnb ) (encoders: libopencore_amrnb )
        amr_wb,
        //AMR-WB (Adaptive Multi-Rate WideBand) (decoders: amrwb libopencore_amrwb ) (encoders: libvo_amrwbenc )
        ape,
        //Monkey's Audio
        atrac1,
        //Atrac 1 (Adaptive TRansform Acoustic Coding)
        atrac3,
        //Atrac 3 (Adaptive TRansform Acoustic Coding 3)
        atrac3p,
        //Sony ATRAC3+
        binkaudio_dct,
        //Bink Audio (DCT)
        binkaudio_rdft,
        //Bink Audio (RDFT)
        bmv_audio,
        //Discworld II BMV audio
        celt,
        //Constrained Energy Lapped Transform (CELT)
        comfortnoise,
        //RFC 3389 Comfort Noise
        cook,
        //Cook / Cooker / Gecko (RealAudio G2)
        dsicinaudio,
        //Delphine Software International CIN audio
        dts,
        //DCA (DTS Coherent Acoustics) (decoders: dca ) (encoders: dca )
        dvaudio,
        //
        eac3,
        //ATSC A/52B (AC-3, E-AC-3)
        evrc,
        //EVRC (Enhanced Variable Rate Codec)
        flac,
        //FLAC (Free Lossless Audio Codec)
        g723_1,
        //G.723.1
        g729,
        //G.729
        gsm,
        //GSM (decoders: gsm libgsm ) (encoders: libgsm )
        gsm_ms,
        //GSM Microsoft variant (decoders: gsm_ms libgsm_ms ) (encoders: libgsm_ms )
        iac,
        //IAC (Indeo Audio Coder)
        ilbc,
        //iLBC (Internet Low Bitrate Codec) (decoders: libilbc ) (encoders: libilbc )
        imc,
        //IMC (Intel Music Coder)
        interplay_dpcm,
        //DPCM Interplay
        libvorbis,
        mace3,
        //MACE (Macintosh Audio Compression/Expansion) 3:1
        mace6,
        //MACE (Macintosh Audio Compression/Expansion) 6:1
        mlp,
        //MLP (Meridian Lossless Packing)
        mp1,
        //MP1 (MPEG audio layer 1) (decoders: mp1 mp1float )
        mp2,
        //MP2 (MPEG audio layer 2) (decoders: mp2 mp2float ) (encoders: mp2 libtwolame )
        mp3,
        //MP3 (MPEG audio layer 3) (decoders: mp3 mp3float ) (encoders: libmp3lame )
        mp3adu,
        //ADU (Application Data Unit) MP3 (MPEG audio layer 3) (decoders: mp3adu mp3adufloat )
        mp3on4,
        //MP3onMP4 (decoders: mp3on4 mp3on4float )
        mp4als,
        //MPEG-4 Audio Lossless Coding (ALS) (decoders: als )
        musepack7,
        //Musepack SV7 (decoders: mpc7 )
        musepack8,
        //Musepack SV8 (decoders: mpc8 )
        nellymoser,
        //Nellymoser Asao
        opus,
        //Opus (Opus Interactive Audio Codec) (decoders: libopus ) (encoders: libopus )
        paf_audio,
        //Amazing Studio Packed Animation File Audio
        pcm_alaw,
        //PCM A-law / G.711 A-law
        pcm_bluray,
        //PCM signed 16|20|24-bit big-endian for Blu-ray media
        pcm_dvd,
        //PCM signed 20|24-bit big-endian
        pcm_f32be,
        //PCM 32-bit floating point big-endian
        pcm_f32le,
        //PCM 32-bit floating point little-endian
        pcm_f64be,
        //PCM 64-bit floating point big-endian
        pcm_f64le,
        //PCM 64-bit floating point little-endian
        pcm_lxf,
        //PCM signed 20-bit little-endian planar
        pcm_mulaw,
        //PCM mu-law / G.711 mu-law
        pcm_s16be,
        //PCM signed 16-bit big-endian
        pcm_s16be_planar,
        //PCM signed 16-bit big-endian planar
        pcm_s16le,
        //PCM signed 16-bit little-endian
        pcm_s16le_planar,
        //PCM signed 16-bit little-endian planar
        pcm_s24be,
        //PCM signed 24-bit big-endian
        pcm_s24daud,
        //PCM D-Cinema audio signed 24-bit
        pcm_s24le,
        //PCM signed 24-bit little-endian
        pcm_s24le_planar,
        //PCM signed 24-bit little-endian planar
        pcm_s32be,
        //PCM signed 32-bit big-endian
        pcm_s32le,
        //PCM signed 32-bit little-endian
        pcm_s32le_planar,
        //PCM signed 32-bit little-endian planar
        pcm_s8,
        //PCM signed 8-bit
        pcm_s8_planar,
        //PCM signed 8-bit planar
        pcm_u16be,
        //PCM unsigned 16-bit big-endian
        pcm_u16le,
        //PCM unsigned 16-bit little-endian
        pcm_u24be,
        //PCM unsigned 24-bit big-endian
        pcm_u24le,
        //PCM unsigned 24-bit little-endian
        pcm_u32be,
        //PCM unsigned 32-bit big-endian
        pcm_u32le,
        //PCM unsigned 32-bit little-endian
        pcm_u8,
        //PCM unsigned 8-bit
        pcm_zork,
        //PCM Zork
        qcelp,
        //QCELP / PureVoice
        qdm2,
        //QDesign Music Codec 2
        qdmc,
        //QDesign Music
        ra_144,
        //RealAudio 1.0 (14.4K) (decoders: real_144 ) (encoders: real_144 )
        ra_288,
        //RealAudio 2.0 (28.8K) (decoders: real_288 )
        ralf,
        //RealAudio Lossless
        roq_dpcm,
        //DPCM id RoQ
        s302m,
        //SMPTE 302M
        shorten,
        //Shorten
        sipr,
        //RealAudio SIPR / ACELP.NET
        smackaudio,
        //Smacker audio (decoders: smackaud )
        smv,
        //SMV (Selectable Mode Vocoder)
        sol_dpcm,
        //DPCM Sol
        sonic,
        //Sonic
        sonicls,
        //Sonic lossless
        speex,
        //Speex (decoders: libspeex ) (encoders: libspeex )
        tak,
        //TAK (Tom's lossless Audio Kompressor)
        truehd,
        //TrueHD
        truespeech,
        //DSP Group TrueSpeech
        tta,
        //TTA (True Audio)
        twinvq,
        //VQF TwinVQ
        vima,
        //LucasArts VIMA audio
        vmdaudio,
        //Sierra VMD audio
        vorbis,
        //Vorbis (decoders: vorbis libvorbis ) (encoders: vorbis libvorbis )
        voxware,
        //Voxware RT29 Metasound
        wavesynth,
        //Wave synthesis pseudo-codec
        wavpack,
        //WavPack
        westwood_snd1,
        //Westwood Audio (SND1) (decoders: ws_snd1 )
        wmalossless,
        //Windows Media Audio Lossless
        wmapro,
        //Windows Media Audio 9 Professional
        wmav1,
        //Windows Media Audio 1
        wmav2,
        //Windows Media Audio 2
        wmavoice,
        //Windows Media Audio Voice
        xan_dpcm
        //DPCM Xan
    }
    public enum Subtitle_Codec
    {
        none,
        copy,
        ass,
        //ASS (Advanced SSA) subtitle
        dvb_subtitle,
        //DVB subtitles (decoders: dvbsub ) (encoders: dvbsub )
        dvb_teletext,
        //DVB teletext
        dvd_subtitle,
        //DVD subtitles (decoders: dvdsub ) (encoders: dvdsub )
        eia_608,
        //EIA-608 closed captions
        hdmv_pgs_subtitle,
        //HDMV Presentation Graphic Stream subtitles (decoders: pgssub )
        jacosub,
        //JACOsub subtitle
        microdvd,
        //MicroDVD subtitle
        mov_text,
        //MOV text
        mpl2,
        //MPL2 subtitle
        pjs,
        //PJS (Phoenix Japanimation Society) subtitle
        realtext,
        //RealText subtitle
        sami,
        //SAMI subtitle
        srt,
        //SubRip subtitle with embedded timing
        ssa,
        //SSA (SubStation Alpha) subtitle
        subrip,
        //SubRip subtitle
        subviewer,
        //SubViewer subtitle
        subviewer1,
        //SubViewer v1 subtitle
        text,
        //raw UTF-8 text
        vplayer,
        //VPlayer subtitle
        webvtt,
        //WebVTT subtitle
        xsub
        //XSUB
    }
    public enum Data_Codec
    {
        //not supported by all transcoders 
        Null,
        Subtitle,
        //ffmpeg
        Private_Data
    }
    public enum Transport
    {
        none,
        _3g2,
        //3GP2 (3GPP2 file format)
        _3gp,
        //3GP (3GPP file format)
        _4xm,
        //4X Technologies
        a64,
        //a64 - video for Commodore 64
        aac,
        //raw ADTS AAC (Advanced Audio Coding)
        ac3,
        //raw AC-3
        act,
        //ACT Voice file format
        adf,
        //Artworx Data Format
        adp,
        //ADP
        adts,
        //ADTS AAC (Advanced Audio Coding)
        adx,
        //CRI ADX
        aea,
        //MD STUDIO audio
        afc,
        //AFC
        aiff,
        //Audio IFF
        alaw,
        //PCM A-law
        amr,
        //3GPP AMR
        anm,
        //Deluxe Paint Animation
        apc,
        //CRYO APC
        ape,
        //Monkey's Audio
        aqtitle,
        //AQTitle subtitles
        asf,
        //ASF (Advanced / Active Streaming Format)
        asf_stream,
        //ASF (Advanced / Active Streaming Format)
        ass,
        //SSA (SubStation Alpha) subtitle
        ast,
        //AST (Audio Stream)
        au,
        //Sun AU
        avi,
        //AVI (Audio Video Interleaved)
        avisynth,
        //AviSynth script
        avm2,
        //SWF (ShockWave Flash) (AVM2)
        avr,
        //AVR (Audio Visual Research)
        avs,
        //AVS
        bethsoftvid,
        //Bethesda Softworks VID
        bfi,
        //Brute Force & Ignorance
        bin,
        //Binary text
        bink,
        //Bink
        bit,
        //G.729 BIT file format
        bmv,
        //Discworld II BMV
        boa,
        //Black Ops Audio
        brstm,
        //BRSTM (Binary Revolution Stream)
        c93,
        //Interplay C93
        caca,
        //caca (color ASCII art) output device
        caf,
        //Apple CAF (Core Audio Format)
        cavsvideo,
        //raw Chinese AVS (Audio Video Standard) video
        cdg,
        //CD Graphics
        cdxl,
        //Commodore CDXL video
        concat,
        //Virtual concatenation script
        copy,
        //pass through
        crc,
        //CRC testing
        data,
        //raw data
        daud,
        //D-Cinema audio
        dfa,
        //Chronomaster DFA
        dirac,
        //raw Dirac
        dnxhd,
        //raw DNxHD (SMPTE VC-3)
        dshow,
        //DirectShow capture
        dsicin,
        //Delphine Software International CIN
        dts,
        //raw DTS
        dtshd,
        //raw DTS-HD
        dv,
        //DV (Digital Video)
        dvd,
        //MPEG-2 PS (DVD VOB)
        dxa,
        //DXA
        ea,
        //Electronic Arts Multimedia
        ea_cdata,
        //Electronic Arts cdata
        eac3,
        //raw E-AC-3
        epaf,
        //Ensoniq Paris Audio File
        f32be,
        //PCM 32-bit floating-point big-endian
        f32le,
        //PCM 32-bit floating-point little-endian
        f4v,
        //F4V Adobe Flash Video
        f64be,
        //PCM 64-bit floating-point big-endian
        f64le,
        //PCM 64-bit floating-point little-endian
        ffm,
        //FFM (FFserver live feed)
        ffmetadata,
        //FFmpeg metadata in text
        film_cpk,
        //Sega FILM / CPK
        filmstrip,
        //Adobe Filmstrip
        flac,
        //raw FLAC
        flic,
        //FLI/FLC/FLX animation
        flv,
        //FLV (Flash Video)
        framecrc,
        //framecrc testing
        framemd5,
        //Per-frame MD5 testing
        frm,
        //Megalux Frame
        g722,
        //raw G.722
        g723_1,
        //raw G.723.1
        g729,
        //G.729 raw format demuxer
        gif,
        //GIF Animation
        gsm,
        //raw GSM
        gxf,
        //GXF (General eXchange Format)
        h261,
        //raw H.261
        h263,
        //raw H.263
        h264,
        //raw H.264 video
        hls,
        //Apple HTTP Live Streaming
        hls_applehttp,
        //Apple HTTP Live Streaming
        ico,
        //Microsoft Windows ICO
        idcin,
        //id Cinematic
        idf,
        //iCE Draw File
        iff,
        //IFF (Interchange File Format)
        ilbc,
        //iLBC storage
        image2,
        //image2 sequence
        image2pipe,
        //piped image2 sequence
        ingenient,
        //raw Ingenient MJPEG
        ipmovie,
        //Interplay MVE
        ipod,
        //iPod H.264 MP4 (MPEG-4 Part 14)
        ircam,
        //Berkeley/IRCAM/CARL Sound Format
        ismv,
        //ISMV/ISMA (Smooth Streaming)
        iss,
        //Funcom ISS
        iv8,
        //IndigoVision 8000 video
        ivf,
        //On2 IVF
        jacosub,
        //JACOsub subtitle format
        jv,
        //Bitmap Brothers JV
        latm,
        //LOAS/LATM
        lavfi,
        //Libavfilter virtual input device
        lmlm4,
        //raw lmlm4
        loas,
        //LOAS AudioSyncStream
        lvf,
        //LVF
        lxf,
        //VR native stream (LXF)
        m4v,
        //raw MPEG-4 video
        matroska,
        //Matroska
        matroska_webm,
        //Matroska / WebM
        md5,
        //MD5 testing
        mgsts,
        //Metal Gear Solid: The Twin Snakes
        microdvd,
        //MicroDVD subtitle format
        mjpeg,
        //raw MJPEG video
        mkvtimestamp_v2,
        //extract pts as timecode v2 format, as defined by mkvtoolnix
        mlp,
        //raw MLP
        mm,
        //American Laser Games MM
        mmf,
        //Yamaha SMAF
        mov,
        //QuickTime / MOV
        mov_mp4_m4a_3gp,
        //3g2,mj2 QuickTime / MOV
        mp2,
        //MP2 (MPEG audio layer 2)
        mp3,
        //MP3 (MPEG audio layer 3)
        mp4,
        //MP4 (MPEG-4 Part 14)
        mpc,
        //Musepack
        mpc8,
        //Musepack SV8
        mpeg,
        //MPEG-1 Systems / MPEG program stream
        mpeg1video,
        //raw MPEG-1 video
        mpeg2video,
        //raw MPEG-2 video
        mpegts,
        //MPEG-TS (MPEG-2 Transport Stream)
        mpegtsraw,
        //raw MPEG-TS (MPEG-2 Transport Stream)
        mpegvideo,
        //raw MPEG video
        mpjpeg,
        //MIME multipart JPEG
        mpl2,
        //MPL2 subtitles
        mpsub,
        //MPlayer subtitles
        msnwctcp,
        //MSN TCP Webcam stream
        mtv,
        //MTV
        mulaw,
        //PCM mu-law
        mv,
        //Silicon Graphics Movie
        mvi,
        //Motion Pixels MVI
        mxf,
        //MXF (Material eXchange Format)
        mxf_d10,
        //MXF (Material eXchange Format) D-10 Mapping
        mxg,
        //MxPEG clip
        nc,
        //NC camera feed
        nistsphere,
        //NIST SPeech HEader REsources
        nsv,
        //Nullsoft Streaming Video
        @null,
        //raw null video
        nut,
        //NUT
        nuv,
        //NuppelVideo
        ogg,
        //Ogg
        oma,
        //Sony OpenMG audio
        paf,
        //Amazing Studio Packed Animation File
        pjs,
        //PJS (Phoenix Japanimation Society) subtitles
        pmp,
        //Playstation Portable PMP
        psp,
        //PSP MP4 (MPEG-4 Part 14)
        psxstr,
        //Sony Playstation STR
        pva,
        //TechnoTrend PVA
        pvf,
        //PVF (Portable Voice Format)
        qcp,
        //QCP
        r3d,
        //REDCODE R3D
        rawvideo,
        //raw video
        realtext,
        //RealText subtitle format
        redspark,
        //RedSpark
        rl2,
        //RL2
        rm,
        //RealMedia
        roq,
        //raw id RoQ
        rpl,
        //RPL / ARMovie
        rsd,
        //GameCube RSD
        rso,
        //Lego Mindstorms RSO
        rtp,
        //RTP output
        rtsp,
        //RTSP output
        s16be,
        //PCM signed 16-bit big-endian
        s16le,
        //PCM signed 16-bit little-endian
        s24be,
        //PCM signed 24-bit big-endian
        s24le,
        //PCM signed 24-bit little-endian
        s32be,
        //PCM signed 32-bit big-endian
        s32le,
        //PCM signed 32-bit little-endian
        s8,
        //PCM signed 8-bit
        sami,
        //SAMI subtitle format
        sap,
        //SAP output
        sbg,
        //SBaGen binaural beats script
        sdl,
        //SDL output device
        sdp,
        //SDP
        segment,
        //segment
        shn,
        //raw Shorten
        siff,
        //Beam Software SIFF
        smjpeg,
        //Loki SDL MJPEG
        smk,
        //Smacker
        smoothstreaming,
        //Smooth Streaming Muxer
        smush,
        //LucasArts Smush
        sol,
        //Sierra SOL
        sox,
        //SoX native
        spdif,
        //IEC 61937 (used on S/PDIF - IEC958)
        srt,
        //SubRip subtitle
        stream_segment_s,
        //segment streaming segment muxer
        subviewer,
        //SubViewer subtitle format
        subviewer1,
        //SubViewer v1 subtitle format
        svcd,
        //MPEG-2 PS (SVCD)
        swf,
        //SWF (ShockWave Flash)
        tak,
        //raw TAK
        tedcaptions,
        //TED Talks captions
        tee,
        //Multiple muxer tee
        thp,
        //THP
        tiertexseq,
        //Tiertex Limited SEQ
        tmv,
        //8088flex TMV
        truehd,
        //raw TrueHD
        tta,
        //TTA (True Audio)
        tty,
        //Tele-typewriter
        txd,
        //Renderware TeXture Dictionary
        u16be,
        //PCM unsigned 16-bit big-endian
        u16le,
        //PCM unsigned 16-bit little-endian
        u24be,
        //PCM unsigned 24-bit big-endian
        u24le,
        //PCM unsigned 24-bit little-endian
        u32be,
        //PCM unsigned 32-bit big-endian
        u32le,
        //PCM unsigned 32-bit little-endian
        u8,
        //PCM unsigned 8-bit
        vc1,
        //raw VC-1 video
        vc1test,
        //VC-1 test bitstream
        vcd,
        //MPEG-1 Systems / MPEG program stream (VCD)
        vfwcap,
        //VfW video capture
        vivo,
        //Vivo
        vmd,
        //Sierra VMD
        vob,
        //MPEG-2 PS (VOB)
        vobsub,
        //VobSub subtitle format
        voc,
        //Creative Voice
        vplayer,
        //VPlayer subtitles
        vqf,
        //Nippon Telegraph and Telephone Corporation (NTT) TwinVQ
        w64,
        //Sony Wave64
        wav,
        //WAV / WAVE (Waveform Audio)
        wc3movie,
        //Wing Commander III movie
        webm,
        //WebM
        webvtt,
        //WebVTT subtitle
        wsaud,
        //Westwood Studios audio
        wsvqa,
        //Westwood Studios VQA
        wtv,
        //Windows Television (WTV)
        wv,
        //WavPack
        xa,
        //Maxis XA
        xbin,
        //eXtended BINary text (XBIN)
        xmv,
        //Microsoft XMV
        xwma,
        //Microsoft xWMA
        yop,
        //Psygnosis YOP
        yuv4mpegpipe
        //YUV4MPEG pipe
    }
}
