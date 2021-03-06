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

    stage('Build') {
      steps {
          bat "dotnet restore"
          script { 
            if (env.BRANCH_NAME == "develop") {                                          
              echo "------------>Build Pruebas<------------"
              bat "${tool 'MSBuild64'}/MSBuild.exe /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=./release /p:Configuration=Pruebas"
            } else {                                   
              echo "------------>Build Produccion<------------"
               bat "${tool 'MSBuild64'}/MSBuild.exe /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=./release /p:Configuration=Produccion"
            }   
          }              
        }
    }

    stage('Stop Services') {
      steps {
          script { 
            if (env.BRANCH_NAME == "develop") {                                          
              echo "------------>Iss Deploy CRBAPISAPTest<------------"
              bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\TEST\\release\\OfflineTemplate\\App_offline.htm' -dest:contentPath=CRBAPISAPTest/App_offline.htm,ComputerName=https://10.10.1.12:8172/msdeploy.axd?site=CRBAPISAPTest,UserName=Administrador,Password=Server#Sap_,AuthType=Basic -allowUntrusted=true -verb:sync")
            } else {                                   
              echo "------------>Iss Deploy APISAP<------------"
              bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\TEST\\release\\OfflineTemplate\\App_offline.htm' -dest:contentPath=APISAP/App_offline.htm,ComputerName=https://10.10.1.12:8172/msdeploy.axd?site=APISAP,UserName=Administrador,Password=Server#Sap_,AuthType=Basic -allowUntrusted=true -verb:sync")
            }   
          }   
        sleep 30      
        }
    }

    stage('Deploy') {
      steps {
          script { 
            if (env.BRANCH_NAME == "develop") {                                          
              echo "------------>Iss Deploy CRBAPISAPTest<------------"
              bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\TEST\\release' -dest:contentPath=CRBAPISAPTest,ComputerName=https://10.10.1.12:8172/msdeploy.axd?site=CRBAPISAPTest,UserName=Administrador,Password=Server#Sap_,AuthType=Basic -allowUntrusted=true -verb:sync")
            } else {                                   
              echo "------------>Iss Deploy APISAP<------------"
              bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\TEST\\release' -dest:contentPath=APISAP,ComputerName=https://10.10.1.12:8172/msdeploy.axd?site=APISAP,UserName=Administrador,Password=Server#Sap_,AuthType=Basic -allowUntrusted=true -verb:sync")
            }   
          }              
        }
    }


  }
        
}


