using System;
using System.Collections.Generic;
using System.Threading;

using BananaTheGame.Terrain;
using BananaTheGame.Terrain.Generators;
using BananaTheGame.Terrain.Processor;

namespace BananaTheGame.Control
{
    public delegate void AbortThreadHandler();
    public class LevelLoader
    {
        private volatile bool keepLooping;
        private Thread thread;
        private IChunkGenerator Generator;
        private EventWaitHandle tileWait;
        private bool waiting;

        //private Queue<Chunk> loadRequest { get; set; }
        private Queue<Chunk> processRequest { get; set; }

        public LevelLoader()
        {
            //Generator = new TestTerrainGenerator();
            tileWait = new EventWaitHandle(false, EventResetMode.AutoReset);
            keepLooping = true;
            //loadRequest = new Queue<Chunk>();
            processRequest = new Queue<Chunk>();
            waiting = false;

            thread = new Thread(new ThreadStart(Loop));
            thread.Name = "Content Loading Thread";
            thread.Start();
            LevelLoader.AbortEvent += new AbortThreadHandler(LevelLoader_AbortEvent);
        }

        void LevelLoader_AbortEvent()
        {
            Stop();
        }

        public void Loop()
        {
            while (keepLooping)
            {
                if (processRequest.Count > 0)
                {
                    Chunk chunk = processRequest.Dequeue();
                    TileProcessor.Process(chunk);
                }
                else
                {
                    waiting = true;
                    tileWait.WaitOne();
                }
            }
        }

        //public void Loop()
        //{
        //    while (keepLooping)
        //    {
        //        if (loadRequest.Count > 0)
        //        {
        //            Chunk work = loadRequest.Dequeue();
        //            loadChunk(work);
        //            work.State = ChunkState.AwaitingProcess;
        //            //processRequest.Enqueue(work);
        //            //ProcessingManager.Process(work);
        //        }
        //        else if (processRequest.Count > 0)
        //        {
        //            Chunk work = processRequest.Dequeue();
        //            if (work.State == ChunkState.Ready || work.State == ChunkState.AwaitingProcess || work.State == ChunkState.InQueue)
        //            {
        //                work.State = ChunkState.Processing;
        //                ProcessingManager.Process(work);
        //                work.State = ChunkState.AwaitingRender;
        //            }
        //            else
        //            {
        //                loadRequest.Enqueue(work);
        //            }
        //        }
        //        else
        //        {
        //            waiting = true;
        //            tileWait.WaitOne();
        //        }
        //    }
        //}

        public void Stop()
        {
            keepLooping = false;
            thread.Abort();
        }

        #region Load
        //public void AddRequest(Chunk chunk)
        //{
        //    if (!loadRequest.Contains(chunk))
        //    {
        //        loadRequest.Enqueue(chunk);
        //        waiting = false;
        //        tileWait.Set();
        //    }
        //}

        public void AddRequest(Chunk chunk)
        {
            if (!processRequest.Contains(chunk))
            {
                processRequest.Enqueue(chunk);
                waiting = false;
                tileWait.Set();
            }
        }

        public void ProcessChunk(Chunk chunk)
        {
            processRequest.Enqueue(chunk);
            waiting = false;
            tileWait.Set();
        }

        //public void LoadXStrip(Vector2Int origin, int startX, int length, int halfLength)
        //{
        //    for (int z = origin.Z - halfLength; z <= origin.Z + halfLength; z++)
        //    {
        //        if (!World.ChunkExists(new Vector2Int(startX, z)))
        //        {
        //            Chunk chunk = new Chunk(new Vector2Int(startX, z));
        //            World.Chunks[startX, z] = chunk;
        //            AddRequest(chunk);
        //            //loadRequest.Enqueue(chunk);
        //            //loadChunk(chunk);
        //        }
        //    }
        //}

        //public void LoadZStrip(Vector2Int origin, int startZ, int length, int halfLength)
        //{
        //    for (int x = origin.X - halfLength; x <= origin.X + halfLength; x++)
        //    {
        //        if (!World.ChunkExists(new Vector2Int(x, startZ)))
        //        {
        //            Chunk chunk = new Chunk(new Vector2Int(x, startZ));
        //            World.Chunks[x, startZ] = chunk;
        //            AddRequest(chunk);
        //            //loadRequest.Enqueue(chunk);
        //            //loadChunk(chunk);
        //        }
        //    }
        //}

        public override string ToString()
        {
            if (waiting)
                return "I";
            return "A";
        }

        //private void loadChunk(Chunk chunk)
        //{
        //    generateChunk(chunk);
        //}

        //private void generateChunk(Chunk chunk)
        //{
        //    Generator.Generate(chunk);
        //}
        #endregion

        public static event AbortThreadHandler AbortEvent;

        public static void AbortAll()
        {
            if (AbortEvent != null)
                AbortEvent();
        }
    }
}
