#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup(){
    // color tracking
    camera.setup(1280, 720);
    
    contour.setMinAreaRadius(10);
    contour.setMaxAreaRadius(100);
    contour.setTargetColor(colorSearch);
    
    colorSearch = {217, 125, 58, 255};
    
    // UDP communication
    ofSetVerticalSync(true);
    ofSetFrameRate(60);
    ofEnableAntiAliasing();
    
    ofxUDPSettings settings;
    settings.sendTo("127.0.0.1", 11999);
    settings.blocking = false;

    udpConnection.Setup(settings);
}

//--------------------------------------------------------------
void ofApp::update(){
    camera.update();
    if(camera.isFrameNew()){
        contour.setTargetColor(colorSearch);
        contour.setThreshold(40);
        contour.findContours(camera);
        std::cout << "value: " << contour.getAverage(0) << endl;
        string message = ofToString(contour.getAverage(0));
        udpConnection.Send(message.c_str(),message.length());
//        std::cout << "value: " << color << endl;
    }
}

//--------------------------------------------------------------
void ofApp::draw(){
    //color = (255);
    camera.draw(0, 0);
    contour.draw();
    
    ofSetColor(color);
    ofFill();
    ofDrawRectangle(camera.getWidth(), 0, 128, 128);
    //std::cout << "value: " << cv::Point2f() << endl;
    
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
//    colorSearch = static_cast<int>(camera.getPixels().getColor(x, y));
    //color = camera.getPixels().getColor(x, y);
    std::cout << "value: " << camera.getPixels().getColor(x, y) << endl;
    std::cout << "value: " << colorSearch << endl;
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
