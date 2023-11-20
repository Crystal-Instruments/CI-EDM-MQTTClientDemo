package org.example.exception;

public class BrokerConnectionException  extends RuntimeException{
    public BrokerConnectionException(String errorMessage, Throwable err){
        super(errorMessage, err);
    }
}
