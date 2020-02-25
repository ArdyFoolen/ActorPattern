using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActorModel
{
    /// <summary>
    /// Actor-Based Class 
    /// </summary>
    /// <remarks>basics: Immutability, Communication and Computation</remarks>
    /// <typeparam name="TMessage"></typeparam>
    public class Actor<TMessage>
        where TMessage : class
    {
        private volatile bool _started;
        private readonly Action<TMessage> _messageHandler;
        private readonly ConcurrentQueue<TMessage> _messagesQueue; // Consider replace with TPL workflow
        private readonly Task _processingTask;
        private readonly CancellationTokenSource _source;

        public Actor(Action<TMessage> messageHandler)
        {
            if (messageHandler == null)
            {
                throw new ArgumentNullException("messageHandler");
            }
            _messagesQueue = new ConcurrentQueue<TMessage>();
            _messageHandler = messageHandler;

            _source = new CancellationTokenSource();
            _processingTask = new Task(() => ProcessMessages(_source.Token), _source.Token, TaskCreationOptions.LongRunning);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------

        public Actor<TMessage> Start()
        {
            if (!_started)
            {
                _processingTask.Start();
                _started = true;
            }

            return this;
        }

        public void Stop()
        {
            Console.WriteLine("PROCESSING STOP REQUESTED");
            _source.Cancel();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------

        public void Send(TMessage message)
        {
            _messagesQueue.Enqueue(message); // any capacity bounding is required here?
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------------

        private void ProcessMessages(CancellationToken ct)
        {
            while (true)
            {
                if (_messagesQueue.Count > 0)
                {
                    TMessage message;
                    var hasRemoved = _messagesQueue.TryDequeue(out message);

                    if (hasRemoved)
                    {
                        _messageHandler(message);
                    }
                }

                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("PROCESSING STOPPED");
                    return;
                }
            }
        }
    }
}
