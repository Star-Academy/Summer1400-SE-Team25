package controllerTest;

import controller.FileHandler;
import model.FileMapper;
import org.junit.*;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class FIleHandlerTest {
    private FileHandler fileHandler;
    private final String INVALID_PATH = "invalid/path";
    private final String VALID_PATH = "src/main/java/EnglishData";

    @Mock
    private FileMapper fileMapper;

    @Before
    public void setUp() {
        this.fileHandler = new FileHandler(fileMapper);
    }

    @Test(expected = NullPointerException.class)
    public void testInitializeMethodException() {
        fileHandler.initialize(INVALID_PATH);
    }

    @Test
    public void testInitializeMethod() {
        fileHandler.initialize(VALID_PATH);
    }
}
