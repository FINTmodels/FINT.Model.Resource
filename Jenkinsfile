pipeline {
  agent none
  stages {
    stage('Build') {
      agent {
        docker {
          label 'docker'
          image 'microsoft/dotnet'
        }
      }
      steps {
        sh 'git clean -fdx'
        sh 'dotnet restore'
        sh 'dotnet build -c Release'
        sh 'dotnet pack -c Release'
        stash includes: '**/Release/*.nupkg', name: 'libs'
      }
    }

    stage('Deploy') {
      agent {
        docker {
          label 'docker'
          image 'microsoft/dotnet'
        }
      }
      environment {
        NUGET_KEY = credentials('fint-nuget')
      }
      when {
        branch 'master'
      }
      steps {
        unstash 'libs'
        archiveArtifacts '**/*.nupkg'
        sh "dotnet nuget push FINT.Model.Resource/bin/Release/FINT.Model.Resource.*.nupkg -k ${NUGET_KEY} -s https://api.nuget.org/v3/index.json"
      }
    }
  }
}