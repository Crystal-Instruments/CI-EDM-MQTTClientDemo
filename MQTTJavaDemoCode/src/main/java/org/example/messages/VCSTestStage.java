package org.example.messages;

public class VCSTestStage {
    public String Timestamp;
    public String Name;
    public String Stage;

    public VCSTestStage() {

    }

    @Override
    public String toString() {
        return "VCSTestStage{" +
                "Timestamp='" + Timestamp + '\'' +
                ", Name='" + Name + '\'' +
                ", Stage='" + Stage + '\'' +
                '}';
    }
}
