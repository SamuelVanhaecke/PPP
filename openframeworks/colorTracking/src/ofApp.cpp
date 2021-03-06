#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup(){
    // Camera setup
    
    // set device to 0 to test with internal webcam
    camera.setDeviceID(1);
    camera.setup(1280, 720);
    
    // Contour finding parameters
    contour.setMinAreaRadius(10);
    contour.setMaxAreaRadius(100);
    contour.setThreshold(40);
    
    // UDP communication
    ofSetVerticalSync(true);
    ofSetFrameRate(60);
    ofEnableAntiAliasing();
    
    ofxUDPSettings settings;
    settings.sendTo("127.0.0.1", 11999);
    settings.blocking = false;

    udpConnection.Setup(settings);
    
    // GUI
    gui.setup("panel");
    gui.add(searchColor.set("color",ofColor(255, 189, 126),ofColor(0,0),ofColor(255,255)));
    
}

//--------------------------------------------------------------
void ofApp::update(){
    camera.update();
    if(camera.isFrameNew()){
        
        contour.findContours(camera);
        
        if(contour.size()>0){
            string message = ofToString(contour.getAverage(0));
            udpConnection.Send(message.c_str(),message.length());
        }
        
        
        
    }
}

//--------------------------------------------------------------
void ofApp::draw(){
//    color = (255);
    camera.draw(0, 0);
    contour.draw();
    gui.draw();
    contour.setTargetColor(searchColor, ofxCv::TRACK_COLOR_HS);
    
}

void ofApp::exit(){
}

//--------------------------------------------------------------
void ofApp::keyPressed(int key){
}

//--------------------------------------------------------------
void ofApp::keyReleased(int key){

}

//--------------------------------------------------------------
void ofApp::mouseMoved(int x, int y ){

}

//--------------------------------------------------------------
void ofApp::mouseDragged(int x, int y, int button){
    color = camera.getPixels().getColor(x, y);
    
}

//--------------------------------------------------------------
void ofApp::mousePressed(int x, int y, int button){
    std::cout << "value: " << camera.getPixels().getColor(x, y) << endl;
}

//--------------------------------------------------------------
void ofApp::mouseReleased(int x, int y, int button){

}

//--------------------------------------------------------------
void ofApp::mouseEntered(int x, int y){

}

//--------------------------------------------------------------
void ofApp::mouseExited(int x, int y){

}

//--------------------------------------------------------------
void ofApp::windowResized(int w, int h){

}

//--------------------------------------------------------------
void ofApp::gotMessage(ofMessage msg){

}

//--------------------------------------------------------------
void ofApp::dragEvent(ofDragInfo dragInfo){ 

}
