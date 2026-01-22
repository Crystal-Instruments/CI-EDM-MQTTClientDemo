The purpose of this example is to demonstrate creating and passing functions to the python client in order to write cleaner code and create a more event driven architecture.

configure_connection is assigned to the user_on_connect field of the mqtt client. Once the mqtt client connects to the broker, the configure_connection method is called, and code meant to run only after the user connects is run. This replaces the while loop in the previous example which has to repeatedly check if the client is connected before progressing.
