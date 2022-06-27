import json
from azure.servicebus import ServiceBusClient, ServiceBusMessage
import pika
#
# Azure Queue Consumer
#
def AzureQueueConsumer(connStr, queueName):
    servicebus_client = ServiceBusClient.from_connection_string(conn_str=connStr, logging_enable=True)
    with ServiceBusClient.from_connection_string(connStr) as client:
        with client.get_queue_receiver(queueName) as receiver:
            received_message_array = receiver.receive_messages(max_message_count=5, max_wait_time=10)  # try to receive a single message within 10 seconds
            if len(received_message_array)>0:
                receiver.complete_message(received_message_array[0])
                client.close()
                print(received_message_array[0].message)
                return received_message_array[0].message;
            else:
                return "";            
#           
#           RabbitMQ Queue Sender
#  
def RabbitQueueMessageProducer(msg):
    if(msg is not None and msg != ''):
        stringmsg = json.loads(str(msg))
        connection = pika.BlockingConnection(pika.ConnectionParameters('localhost'))
        channel = connection.channel()
        channel.queue_declare(queue='mensagem')
        channel.basic_publish(exchange='',
                            routing_key='mensagem',
                            body= stringmsg.encode('utf-8') 
                            )
        print(" [x] Sent"+str(msg))
    else:
        print("Empty string from queue")

def main(CONNECTION_STR, QUEUE_NAME):
    while(True):
        print("Start queue processes...")
        #AzureQueueConsumer(CONNECTION_STR, QUEUE_NAME)
        RabbitQueueMessageProducer(AzureQueueConsumer(CONNECTION_STR, QUEUE_NAME))
        print("Finished")

main(
    "Endpoint=sb://dconto.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=aDAmnosCtn3w9p91CBhuKy6ezLctiwsYwRCNhfq67yo=",
    "availablecurrencies-queue"
    )