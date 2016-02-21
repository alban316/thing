using System;
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
        private const int DEFAULT_SPEED = 20;
        private const int SPEED_INCREMENT = 10;
        private const int MIN_SPEED = 30;
        private const int MAX_SPEED = 10;


        //private enum Speed : int { Slow = 50, Medium = 35, Fast = 25};
        //private enum Speed : int {Slow = 50, Medium = 35, Fast = 25, VeryFast = 10 };

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
\0IMMM;00
__[___[__
";

        private const string SPCARLEFT = @"
00IMMM;0\
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
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }


        public class Bounds
        {
            public Point Min { get; set; }
            public Point Max { get; set; }

            public Bounds(Point min, Point max)
            {
                Min = min;
                Max = max;
            }

            public static bool Collision ( Bounds a, Bounds b, bool inside = false)
            {
                bool result = false;
                if (inside) // object (a) is inside a box (b); move freely within; collision with walls
                {
                    if (a.Min.X < b.Min.X || a.Max.X > b.Max.X || a.Min.Y < b.Min.Y || a.Max.Y > b.Max.Y)
                    {
                        result = true;

                    }
                }

                else // object (a) is outside a box (b); cannot cross into box
                {

                }

                return result;
            }
        }

        class Item
        {
            public Point Loc { get; set; }
            public Point Size { get; set; }

            public Item(int x, int y, int width, int height)
            {
                Loc = new Point(x, y);
                Size = new Point(width, height);
            }

            public Bounds Bounds()
            {
                Point min = Loc;
                Point max = new Point(Loc.X + Size.X, Loc.Y + Size.Y);
                Bounds b = new Bounds(min, max);
                return b;
            }
        }

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

            public bool Update()
            {
                bool result = false;
                if (bgWatch.ElapsedMilliseconds > Interval)
                {
                    shift++;

                    if (shift > WIDTH - 1)
                    {
                        shift = 0;
                    }

                    result = true;
                    bgWatch.Restart();
                }

                return result;
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

            public int Width { get; set; }
            public int Height { get; set; }
            private string image;
            private int frameSize;
            private int currentFrame;
            private int maxFrames;
            public int Interval { get; set; }
            private Stopwatch bgWatch;


            public Sprite(string image,  int height, int width, int numFrames, int interval = 10)
            {
                this.image = image;
                this.Height = height;
                this.Width = width;
                this.frameSize = height * width;
                this.maxFrames = numFrames;
                this.currentFrame = 0;
                this.Interval = interval;
                this.bgWatch = new Stopwatch();
                bgWatch.Start();
            }

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


            public string Overlay(string background, Point loc)
            {

                string frame = image.Substring(currentFrame * frameSize, frameSize);

                for (int i = 0; i < Height; i++) //for each line of the sprite
                {
                    string spline = frame.Substring(i * Width, Width);
                    string sceneLeft = background.Substring(0, (loc.Y + i) * WIDTH + loc.X);
                    string sceneRight = background.Substring((loc.Y + i) * WIDTH + loc.X + Width, background.Length - Width - sceneLeft.Length);

                    background = sceneLeft + spline + sceneRight;
                }

                return background;

            }


        } //END nested class Sprite


        
        class Animal : Item // currently hard-coded for a deer
        {
            public enum State : int { Standing, Running};
            private Stopwatch timer;
            private int standsForMs = 750;
            private int runsForMs = 3000;
            private int roadStepMs = 150;
            private int lastMs = 0;

            public Animal(int x, int y, int width, int height) : base(x,y,width, height)
            {
                timer = new Stopwatch();
                timer.Start();
            }



            public State CurrentState()
            {

                if (Loc.Y == 12 || Loc.Y == 27)
                {
                    return State.Standing;
                }

                else
                {
                    return State.Running;
                }

            }

            public void Update()
            {
                int stoodAtBottom = standsForMs;
                int ranToTop = standsForMs + runsForMs;
                int stoodAtTop = standsForMs * 2 + runsForMs;
                int ranToBottom = standsForMs * 2 + runsForMs * 2;

                if (Loc.X < 1)
                {
                    Loc.X = 75;
                }

                if (timer.ElapsedMilliseconds >= stoodAtBottom && timer.ElapsedMilliseconds < ranToTop && timer.ElapsedMilliseconds > lastMs + roadStepMs)
                {
                    Loc.Y--;

                    if (Loc.Y < 12)
                    {
                        Loc.Y = 12;
                    }

                    lastMs = (int)timer.ElapsedMilliseconds;

                }

                else if (timer.ElapsedMilliseconds >= stoodAtTop && timer.ElapsedMilliseconds < ranToBottom && timer.ElapsedMilliseconds > lastMs + roadStepMs)
                {
                    Loc.Y++;

                    if (Loc.Y > 27)
                    {
                        Loc.Y = 27;
                    }

                    lastMs = (int)timer.ElapsedMilliseconds;
                }

                else if (timer.ElapsedMilliseconds >= ranToBottom)
                {
                    timer.Restart();
                    Loc.Y = 27;
                    lastMs = 0;
                }
            }

        } //END nested class Animal


        class PlayerCar : Item
        {
            public PlayerCar(int x, int y, int width, int height) : base(x, y, width, height)
            {

            }

            public int Speed { get; set; }
        }

        private Background[] bg = new Background[BG_NUMLAYERS];
        private string scene;
        private Sprite[] sprite = new Sprite[SP_NUMSPRITES];
        private Sprite car;
        private Sprite deerRunning;
        private Sprite deerStanding;
        private Sprite car_left;

        private PlayerCar pc;
        private PlayerCar npcCar;
        private Animal npcDeer;

        public Bounds road;

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
            
            //init backgrounds
            bg[0] = new Background(bgFar, (int)DEFAULT_SPEED + 30);
            bg[1] = new Background(bgNear, (int)DEFAULT_SPEED + 15);
            bg[2] = new Background(bgRoad, (int)DEFAULT_SPEED);
            bg[3] = new Background(bgFront, (int)DEFAULT_SPEED - 15);

            //starting with pre-defined sprite constants...
            //strip Crlf, replace zeroes with spaces, and promote other bytes to their high order (+128) CP437 counterparts
            string imgCar = CP437.Promote(StripCrlf(SPCAR), "0").Replace("0", " ");
            string imgCarLeft = CP437.Promote(StripCrlf(SPCARLEFT), "0").Replace("0", " ");
            string imgDeerStanding = StripCrlf(SPDEER_STAND).Replace("0", " ");
            string imgDeerRunning = StripCrlf(SPDEER_RUN).Replace("0", " ");

            //init sprites
            car = new Sprite(imgCar, 2, 9, 1);
            car_left = new Sprite(imgCarLeft, 2, 9, 1);
            deerStanding = new Sprite(imgDeerStanding, 2, 4, 2, 750);
            deerRunning = new Sprite(imgDeerRunning, 2, 4, 4, 150);

            //init game characters
            pc = new PlayerCar(20, 20, car.Width, car.Height);
            pc.Speed = DEFAULT_SPEED;
            npcDeer = new Animal(75, 27, deerStanding.Width, deerStanding.Height); // was x = 55
            npcCar = new PlayerCar(70, 15, car.Width, car.Height);

            //init boundaries
            Point roadMin = new Point(0, 12);
            Point roadMax = new Point(79, 29);
            road = new Bounds(roadMin, roadMax); 

        }

        private void DrawScene()
        {
            // start by layering background layers
            scene = bg[0].Shifted();
            for (int i = 1; i < BG_NUMLAYERS; i++)
            {
                scene = Background.Overlay(scene, bg[i].Shifted());
            }

            // add player car
            scene = car.Overlay(scene, pc.Loc);

            // add deer NPC
            if (npcDeer.CurrentState() == Animal.State.Running)
            {
                scene = deerRunning.Overlay(scene, npcDeer.Loc);
            }

            else
            {
                scene = deerStanding.Overlay(scene, npcDeer.Loc);
            }

            // add oncoming car
            scene = car_left.Overlay(scene, npcCar.Loc);
            
        }


        private void Update()
        {
            // adjust background speeds per player speed
            bg[0].Interval = (int)pc.Speed + SPEED_INCREMENT * 2;
            bg[1].Interval = (int)pc.Speed + SPEED_INCREMENT;
            bg[2].Interval = (int)pc.Speed;
            bg[3].Interval = (int)pc.Speed - SPEED_INCREMENT;

            // update background parallax scrolling

            bool roadShifted = false;
            for (int i = 0; i < BG_NUMLAYERS; i++)
            {
                bool bgShifted = bg[i].Update();
                if (i == 2)
                {
                    roadShifted = bgShifted;
                }
            }

            // do ai action & scroll sprites synchronous to pc.Speed
            if (roadShifted)
            {
                npcDeer.Loc.X--;
                npcCar.Loc.X--;
            }
            npcDeer.Update();

            // update sprite animation frames
            deerStanding.Update();
            deerRunning.Update();

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
                        pc.Loc.Y--;
                        if (Bounds.Collision(pc.Bounds(), road, true))
                        {
                            pc.Loc.Y = road.Min.Y;
                        }

                        break;

                    case ConsoleKey.DownArrow:
                        pc.Loc.Y++;
                        if (Bounds.Collision(pc.Bounds(), road, true))
                        {
                            pc.Loc.Y = road.Max.Y - pc.Size.Y;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        pc.Speed += SPEED_INCREMENT;
                        if (pc.Speed > MIN_SPEED) //higher speed in ms is slower
                        {
                            pc.Speed = MIN_SPEED;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        pc.Speed -= SPEED_INCREMENT;
                        if (pc.Speed < MAX_SPEED) //lower speed in ms is faster
                        {
                            pc.Speed = MAX_SPEED;
                        }
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
