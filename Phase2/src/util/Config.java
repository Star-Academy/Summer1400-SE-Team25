package util;

import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

public class Config extends Properties {
    private static boolean hasInitialize = false;
    final private static Config instance = new Config();

    public static String retrieveProperty(String key) {
        if (!hasInitialize)
            Config.initialize();
        return instance.getProperty(key);
    }

    private static void initialize() {
        try {
            FileReader fileReader = new FileReader(Setting.configFileAddress);
            instance.load(fileReader);
            hasInitialize = true;
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }
}