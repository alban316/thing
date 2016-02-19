﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace thing
{
    class Game
    {
        private const int WIDTH = 80;
        private const int HEIGHT = 40;
        private const int BG_NUMLAYERS = 4;
        private const int SP_NUMSPRITES = 1;
        private enum Speed : int {Slow = 50, Medium = 35, Fast = 25, VeryFast = 10 };

        private const string BGTEST = @"
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
11111111111111111111111111111111111111111111111111111111111111111111111111111111
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
22222222222222222222222222222222222222222222222222222222222222222222222222222222
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
33333333333333333333333333333333333333333333333333333333333333333333333333333333
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
00000000001111111111222222222233333333334444444444555555555566666666667777777777
44444444444444444444444444444444444444444444444444444444444444444444444444444444
";

        private const string BGNEAR = @"
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
`````````````````````````````````````````````````````1111```````````````````````
``````````````````````````````````````````````````1111111111````````````````````
``````````````````````````````````````````````1111111111111111``````````````````
``````````111````````````````````````````1111111111111111111111111``````````````
```````1111111`````````````````````1111111111111111111111111111111111```````````
`````11111111111```````111111111111111111111111111111111111111111111111111``````
11111111111111111111111111111111111111111111111111111111111111111111111111111111
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
";

        private const string BGFAR = @"
````````````````````````````````````````````````````````````````````````````````
`````````````````````00000``````````````````````````````````````````````````````
`````````````````````000000`````````````````````````````````````````````````````
`````````````````````000000`````````````````````````````````````````````````````
`````````````````````000000`````````````````````````````````````````````````````
`````````````````````0000000````````````````````````````````````````````````````
`````````````````````000000000``````````````````````````````````````````````````
``````````````````000000000000000```````````````````````````````````````````````
``````````00000000000000000000000000000000``````````````````````````````````````
00000000000000000000000000000000000000000000000000000000000000000000000000000000
00000000000000000000000000000000000000000000000000000000000000000000000000000000
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
";

        private const string BGROAD = @"
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````D````D````D````D````D````D````D````D````D````D````D````D````D````D````D````D
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
";
        //```~~~`````~~~`````~~~`````~~~`````~~~`````~~~`````~~~`````~~~`````~~~`````~~~``

        private const string BGFRONT = @"
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
````````````````````````````````````````````````````````````````````````````````
22222222222222222222222222222222222222222222222222222222222222222222222222222222
22211222222222222222222222222222222222222222222222222222222222222222222222222222
22222222222222222222222222222222222222222222222222222222222222222222222222222222
22222222222222222222222222222222222222222222221112222222222222222222222222222222
22222222222222222222222222222222222222222222222222222222222222222222222222222222
22222222222222211122222222222222222222222222222222222222222222222222222222222222
22222222222222222222222222222222222222222222222222222222222222222222222222222222
22222222222222222222222222222222222222222222222222222222222222222222222222222222
22222222222222222222222222222222222222222222222222222222222222222222111222222222
22222222222222222222222222222222222222222222222222222222222222222222222222222222
22222222222222222222222222222222222222222222222222222222222222222222222222222222
";

        private const string SPCAR = @"
00IMMM;00
__[___[__
";

        private const string SPTEST = @"
XXXX
XXXX
YYYY
YYYY
";


        private const string SPDEER_RUN = @"
<__~
/0/0
<__~
<0<0
<__~
0\0\
<__~
0\0\
";

        private const string SPDEER_STAND = @"
<__~
0|0| 
>__~
0|0|
";


        class Background
        {
            private const int DEFAULT_INTERVAL = 10; //milliseconds
            public string Image { get; set; }
            public int Interval { get; set; }
            private Stopwatch bgWatch;
            private int shift;

            public Background(string image, int interval = DEFAULT_INTERVAL)
            {
                Image = image;
                bgWatch = new Stopwatch();
                bgWatch.Start();
                shift = 0;
                Interval = interval;
            }

            public static string Overlay(string far, string near)
            {
                if (far.Length == near.Length)
                {
                    char[] arrFar = far.ToCharArray();
                    char[] arrNear = near.ToCharArray();

                    for (int i = 0; i < arrFar.Length; i++)
                    {
                        if (arrNear[i] == ' ')
                        {
                            arrNear[i] = arrFar[i];
                        }
                    }

                    string result = new string(arrNear);
                    return result;
                }

                else
                {
                    return near;
                }
            }

            public void Update()
            {
                if (bgWatch.ElapsedMilliseconds > Interval)
                {
                    shift++;

                    if (shift > WIDTH - 1)
                    {
                        shift = 0;
                    }

                    bgWatch.Restart();
                }
            }

            public string Shifted()
            {
                string result = String.Empty;
                for (int i = 0; i < HEIGHT; i++)
                {
                    result += Image.Substring(i * WIDTH + shift, WIDTH - shift) + Image.Substring(i * WIDTH, shift);
                }

                return result;
            }

        } // END nested class "Background"


        class CP437 //https://en.wikipedia.org/wiki/Code_page_437
        {
            //private char[] charSet;

            //public CP437()
            //{
            //    //load code page 437 into a handy array
            //    //recall that 7-10,13 are not useful; Beep, Backspace, Tab, Line feed, Carriage return, respectively
            //    charSet = new char[255];
            //    byte b; int i;
            //    for (b = 0, i = 0; b < byte.MaxValue; b++, i++)
            //    {
            //        charSet[i] = Encoding.GetEncoding(437).GetChars(new byte[] { b })[0];
            //    }
            //}

            //public string Promote(string inString, string ignoreString)
            //{

            //}

            public static char GetChar()
            {
                throw new NotImplementedException();
            }

            public static string Promote(string inString, string ignoreString)
            {
                char[] inChar = inString.ToCharArray();
                char[] ignoreChar = ignoreString.ToCharArray();

                for (int i = 0; i < inChar.Length; i++)
                {
                    bool ignore = false;
                    for (int j = 0; j < ignoreChar.Length; j++)
                    {
                        if (inChar[i] == ignoreChar[j])
                        {
                            ignore = true;
                            break;
                        }
                    }

                    if (!ignore)
                    {
                        byte b = (byte)((int)inChar[i] + 128);
                        inChar[i] = Encoding.GetEncoding(437).GetChars(new byte[] { b })[0];
                    }
                }

                string result = new string(inChar);
                return result;
            }

        } //END nested class CP437


        public class Sprite
        {
            public enum Direction : int { Up, Down, Left, Right};

            private int width;
            private int height;
            private string image;
            private int frameSize;
            private int currentFrame;
            private int maxFrames;
            public int Interval { get; set; }
            private Stopwatch bgWatch;

            /*
            private int lowBoundX;
            private int lowBoundY;
            private int hiBoundX;
            private int hiBoundY;
                private int locx;
            private int locy;
            int locx, int locy,
            int lowBoundX, int lowBoundY, int hiBoundX, int hiBoundY,
            this.locx = locx;
            this.locy = locy;
            this.lowBoundX = lowBoundX;
            this.hiBoundX = hiBoundX;
            this.lowBoundY = lowBoundY;
            this.hiBoundY = hiBoundY;
            */

            public Sprite(string image,  int height, int width, int numFrames, int interval = 10)
            {
                this.image = image;
                this.height = height;
                this.width = width;
                this.frameSize = height * width;
                this.maxFrames = numFrames;
                this.currentFrame = 0;
                this.Interval = interval;
                this.bgWatch = new Stopwatch();
                bgWatch.Start();
            }

            /*
            public void Move(Direction direction)
            {
                switch (direction)
                {
                    case Direction.Up:
                        if (locy > lowBoundY)
                        {
                            locy--;
                        }
                        break;
                    case Direction.Down:
                        if (locy < hiBoundY)
                        {
                            locy++;
                        }
                        break;
                    case Direction.Left:
                        if (locx > lowBoundX)
                        {
                            locx--;
                        }
                        break;
                    case Direction.Right:
                        if (locx < hiBoundX)
                        {
                            locx++;
                        }
                        break;
                }
            }
            */

            public void Update()
            {
                if (bgWatch.ElapsedMilliseconds > Interval)
                {
                    currentFrame++;
                    if (currentFrame >= maxFrames)
                    {
                        currentFrame = 0;
                    }

                    bgWatch.Restart();
                }
            }


            public string Overlay(string background, int locx, int locy)
            {
                //TO DO: account for animated sprites with multiple frames!!
                // known working for single frame!!!!
                //for (int i = 0; i < height; i++) //for each line of the sprite
                //{
                //    string spline = image.Substring(i * width, width);
                //    string sceneLeft = background.Substring(0, (locy + i) * WIDTH + locx);
                //    string sceneRight = background.Substring((locy + i) * WIDTH + locx + width, background.Length - width - sceneLeft.Length);

                //    background = sceneLeft + spline + sceneRight;
                //}

                string frame = image.Substring(currentFrame * frameSize, frameSize);

                for (int i = 0; i < height; i++) //for each line of the sprite
                {
                    string spline = frame.Substring(i * width, width);
                    string sceneLeft = background.Substring(0, (locy + i) * WIDTH + locx);
                    string sceneRight = background.Substring((locy + i) * WIDTH + locx + width, background.Length - width - sceneLeft.Length);

                    background = sceneLeft + spline + sceneRight;
                }

                return background;

            }


        } //END nested class Sprite


        
        class Animal  // currently hard-coded for a deer
        {
            private int x;
            private int y;
            public enum State : int { Standing, Running};
            private State currentState;
            private Stopwatch stateTimer;
            private Stopwatch runTimer;
            private Sprite[] sprite;

            public State CurrentState { get; }

            public Animal(int x, int y)
            {
                this.x = x;
                this.y = y;
                stateTimer = new Stopwatch();
                stateTimer.Start();
                runTimer = new Stopwatch();
                runTimer.Start();
                currentState = State.Standing;

                string imgDeerRunning = StripCrlf(SPDEER_RUN).Replace("0", " ");
                string imgDeerStanding = StripCrlf(SPDEER_STAND).Replace("0", " ");

                sprite = new Sprite[]
                {
                    new Sprite(imgDeerRunning, 2, 4, 4, 75),
                    new Sprite(imgDeerRunning, 2, 4, 2, 500)
                };

            }

            public Sprite[] Sprite { get; }
            public int X { get; }
            public int Y { get; }

            public void Update()
            {
                if (stateTimer.ElapsedMilliseconds > 0 && stateTimer.ElapsedMilliseconds < 2000)
                {
                    currentState = State.Standing;
                }

                else if (stateTimer.ElapsedMilliseconds >= 2001 && stateTimer.ElapsedMilliseconds < 5000)
                {
                    currentState = State.Running;
                    if (runTimer.ElapsedMilliseconds > 75)
                    {
                        if (y > 12)
                        {
                            y--;
                        }

                        if (x > 35)
                        {
                            x--;
                        }

                        runTimer.Restart();
                    }
                }

                else if (stateTimer.ElapsedMilliseconds >= 5001 && stateTimer.ElapsedMilliseconds < 7000)
                {
                    currentState = State.Standing;
                }

                else
                {
                    currentState = State.Running;

                    if (stateTimer.ElapsedMilliseconds > 9999)
                    {
                        stateTimer.Restart();
                    }
                }
            }

        } //END nested class Animal


        private Background[] bg = new Background[BG_NUMLAYERS];
        private string scene;
        private Sprite[] sprite = new Sprite[SP_NUMSPRITES];
        private Sprite player;
        private Animal animal;


        public static string StripCrlf(string inString)
        {
            return inString.Replace("\r\n", String.Empty);
        }


        private void InitGameAssets()
        {
            //starting with pre-defined background constants...
            //strip Crlf, replace zeroes (0's) with spaces, and promote other bytes to their high order (+128) CP437 counterparts
            string bgFar = CP437.Promote(StripCrlf(BGFAR), "`").Replace("`", " ");
            string bgNear = CP437.Promote(StripCrlf(BGNEAR), "`").Replace("`", " ");
            string bgRoad = CP437.Promote(StripCrlf(BGROAD), "`").Replace("`", " ");
            string bgFront = CP437.Promote(StripCrlf(BGFRONT), "`").Replace("`", " ");
            
            bg[0] = new Background(bgFar, (int)Speed.Slow);
            bg[1] = new Background(bgNear, (int)Speed.Medium);
            bg[2] = new Background(bgRoad, (int)Speed.Fast);
            bg[3] = new Background(bgFront, (int)Speed.VeryFast);

            //starting with pre-defined sprite constants...
            //strip Crlf, replace zeroes with spaces, and promote other bytes to their high order (+128) CP437 counterparts
            string imgCar = CP437.Promote(StripCrlf(SPCAR), "0").Replace("0", " ");

            animal = new Animal(55, 27);

            /*
            player = new Sprite(
                imgCar,      //image
                20,         //locx
                20,         //locy
                2,          //height
                9,          //width
                0,          //lowBoundX
                12,         //lowBoundY
                WIDTH - 9,  //hiBoundX
                29 - 2,     //hiBoundY
                1           //num frames
                );
                */


        }

        private void DrawScene()
        {

            // start by layering background layers
            scene = bg[0].Shifted();
            for (int i = 1; i < BG_NUMLAYERS; i++)
            {
                scene = Background.Overlay(scene, bg[i].Shifted());
            }

            // add sprites
            //scene = player.Overlay(scene);
            //scene = spDeer.Overlay(scene);
            scene = animal.Sprite[(int)animal.CurrentState].Overlay(scene, animal.X, animal.Y);

        }


        private void Update()
        {
            // do ai action



            // update background parallax scrolling
            for (int i = 0; i < BG_NUMLAYERS; i++)
            {
                bg[i].Update();
            }

            // update sprite animation frames
            //spDeer.Update();
            animal.Update();
            

        }

        private void Render()
        {

            //Console.SetCursorPosition(0, 0);
            //Console.Write(scene.Substring(0, WIDTH * HEIGHT - 1));  //writing entire scene with wrapped string seems to flicker!

            //flicker is reduced by writing 1 line at-a-time
            for (int y = 0; y < HEIGHT - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(scene.Substring(y * WIDTH, WIDTH));
            }

        }

        public void RunGame()
        {
            //init
            InitGameAssets();

            Console.Clear();
            Console.CursorVisible = false;
            Console.Title = "Thing";
            Console.SetWindowSize(WIDTH, HEIGHT);
            Console.SetBufferSize(WIDTH, HEIGHT);

            ConsoleKeyInfo pressed;

         
            do //outer loop processes input & continues inner loop
            {
                // inner frame render loop
                while (!Console.KeyAvailable)
                {
                    DrawScene();
                    Render();
                    Update();
                }

                pressed = Console.ReadKey(true);
                switch (pressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        //player.Move(Sprite.Direction.Up);
                        break;

                    case ConsoleKey.DownArrow:
                        //player.Move(Sprite.Direction.Down);
                        break;

                    case ConsoleKey.LeftArrow:
                        break;

                    case ConsoleKey.RightArrow:
                        break;
                }

            } while (pressed.Key != ConsoleKey.Escape);
            

        } //RunGame()

    } // class game

}


/*

                        all this shifting and stopwatch crap needs to be pushed into the background class



                        string far = bgFar.Image.Substring(y * 80 + bgFar.Shift, 80 - bgFar.Shift) + bgFar.Image.Substring(y * 80, bgFar.Shift);
                        string near = bgNear.Image.Substring(y * 80 + bgNear.Shift, 80 - bgNear.Shift) + bgNear.Image.Substring(y * 80, bgNear.Shift);

                        string row = Background.Overlay(far, near);
                        //string row = bgNear.Substring(y * 80 + shift, 80 - shift) + bgNear.Substring(y * 80, shift); //original

                        Console.Write(row);
                    }

                    if (bgFar.BGWatch.ElapsedMilliseconds > bgFar.Interval)
                    {
                        bgFar.Shift++;
                        if (bgFar.Shift > 79)
                        {
                            bgFar.Shift = 0;
                        }

                        bgFar.BGWatch.Restart();
                    }


                    if (bgNear.BGWatch.ElapsedMilliseconds > bgNear.Interval)
                    {
                        bgNear.Shift++;
                        if (bgNear.Shift > 79)
                        {
                            bgNear.Shift = 0;
                        }

                        bgNear.BGWatch.Restart();
                    }

                    for (int shift = 0; shift < 79; shift++)
            {
                for (int y = 0; y < 12; y++)
                {
                    Console.SetCursorPosition(0, y);
                    string row = bgNear.Substring(y * 80 + shift, 80 - shift) + bgNear.Substring(y * 80, shift);
                    Console.Write(row);
                }

                System.Threading.Thread.Sleep(10);
            }


//default rendering
//for (int y = 0; y < 12; y++)
//{
//    Console.SetCursorPosition(0, y);
//    Console.Write(bgFar.Substring(y * 80, 80));
//}

//wrap rendering shifted left by 1

//int y = 0;
//int shift = 1;
//string row;
//Console.SetCursorPosition(0, y);

//row = _bgx.Substring(y + shift, 80 - shift) +_bgx.Substring(0, shift);
//Console.Write(row);

//y = 1;
//row = _bgx.Substring(y * 80 + shift * y, 80 - shift * y) + _bgx.Substring(y * 80, shift * y);
//Console.Write(row);

//y = 2;
//row = _bgx.Substring(y * 80 + shift, 80 - shift) + _bgx.Substring(y * 80, shift);
//Console.Write(row);
*/