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
          url:'https://github.com/lacumbreSistemas/VerificacionFacturasAPI.git'
          ]]
        ])
      }
    }


    stage('Restore Nugets') {
        steps {
          echo '------------>Restaurando paquetes de nugets<------------'
          bat "nuget restore VerificacionFacturasAPI.sln"
        }
    }

    stage('Static Code Analysis') {
      when {
                branch 'develop'
      }
      steps {
        echo '------------>Análisis de código estático<------------'
        withSonarQubeEnv('sonarcube') { 
            bat "${tool name:'sonarscannernetframework' , type:'hudson.plugins.sonar.MsBuildSQRunnerInstallation'}/SonarScanner.MSBuild.exe begin /k:sonar.VerificacionFacturasAPI /n:sonar.VerificacionFacturasAPI"
            bat "${tool 'MSBuild64'}/MSBuild.exe /t:build"
            bat "${tool name:'sonarscannernetframework' , type:'hudson.plugins.sonar.MsBuildSQRunnerInstallation'}/SonarScanner.MSBuild.exe end"
        }
      }
    }

    stage('Build And Deploy Colonial 1') {
      when {
                branch 'main'
      }
      steps {
        echo '------------>Deploy to 10.10.1.8<------------'
        bat "${tool 'MSBuild64'}/MSBuild.exe /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=./release /p:Configuration=Colonial1"
        bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\VerificacionFacturasAPI\\release' -dest:contentPath=VerificarFacturasAPI,ComputerName=https://10.10.1.8:8172/msdeploy.axd?site=VerificarFacturasAPI,UserName=SVRCOLONIAL1\\Administrador,Password=Virt#Col1,AuthType=Basic -allowUntrusted=true -verb:sync")
      }
    }

    stage('Build And Deploy Colonial 2') {
      when {
                branch 'main'
      }
      steps {
        echo '------------>Deploy to 10.10.2.8<------------'
        bat "${tool 'MSBuild64'}/MSBuild.exe /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=./release /p:Configuration=Colonial2"
        bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\VerificacionFacturasAPI\\release' -dest:contentPath=VerificacionFacturasAPI,ComputerName=https://10.10.2.8:8172/msdeploy.axd?site=VerificacionFacturasAPI,UserName=SVRCOL2\\Administrador,Password=Virt#Col2,AuthType=Basic -allowUntrusted=true -verb:sync")
      }
    }


    stage('Build And Deploy Colonial 3') {
      when {
                branch 'main'
      }
      steps {
        echo '------------>Deploy to 10.10.10.8<------------'
        bat "${tool 'MSBuild64'}/MSBuild.exe /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=./release /p:Configuration=Colonial3"
        bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\VerificacionFacturasAPI\\release' -dest:contentPath=VerificacionFacturasAPI,ComputerName=https://10.10.10.8:8172/msdeploy.axd?site=VerificacionFacturasAPI,UserName=COLONIAL3\\Administrador,Password=Virt#Col3,AuthType=Basic -allowUntrusted=true -verb:sync")
      }
    }

    stage('Build And Deploy Colonial 4') {
      when {
                branch 'main'
      }
      steps {
        echo '------------>Deploy to 10.10.12.8<------------'
        bat "${tool 'MSBuild64'}/MSBuild.exe /p:DeployOnBuild=True /p:DeployDefaultTarget=WebPublish /p:WebPublishMethod=FileSystem /p:DeleteExistingFiles=True /p:publishUrl=./release /p:Configuration=Colonial4"
        bat ( script: "msdeploy.exe -source:contentPath='${WORKSPACE}\\VerificacionFacturasAPI\\release' -dest:contentPath=VerificacionFacturasAPI,ComputerName=https://10.10.12.8:8172/msdeploy.axd?site=VerificacionFacturasAPI,UserName=SVRCOL4-F\\Administrador,Password=Virt#Col4,AuthType=Basic -allowUntrusted=true -verb:sync")
      }
    }

  }
        
}


