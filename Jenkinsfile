pipeline { 
   //Opciones específicas de Pipeline dentro del Pipeline
  options {
    buildDiscarder(logRotator(numToKeepStr: '3'))
 	  disableConcurrentBuilds()
  }
    agent any 
        stages { 

  stage('Checkout') {
      steps{
        echo "------------>Checkout<------------"
        checkout([
          $class: 'GitSCM', 
          branches: scm.branches, 
          doGenerateSubmoduleConfigurations: false, 
          extensions: [],
          submoduleCfg: [], 
          userRemoteConfigs: [[
          credentialsId: 'lacumbre.github', 
          url:'https://github.com/lacumbreSistemas/CBR_API_SAP.git'
          ]]
        ])
      }
    }


    stage('Restore Nugets') {
        steps {
          echo '------------>Restaurando paquetes de nugets<------------'
          bat "nuget restore CBRAPISAP.sln"
        }
    }

    stage('Static Code Analysis') {
      when {
                branch 'develop'
      }
      steps {
        echo '------------>Análisis de código estático<------------'
        withSonarQubeEnv('sonarcube') { 
            bat "${tool name:'sonarscannernetframework' , type:'hudson.plugins.sonar.MsBuildSQRunnerInstallation'}/SonarScanner.MSBuild.exe begin /k:sonar.CBR_API_SAP /n:sonar.CBR_API_SAP"
            bat "${tool 'MSBuild64'}/MSBuild.exe /t:build"
            bat "${tool name:'sonarscannernetframework' , type:'hudson.plugins.sonar.MsBuildSQRunnerInstallation'}/SonarScanner.MSBuild.exe end"
        }
      }
    }


  }
        
}


