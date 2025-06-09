import React, { useState } from 'react';
import { StyleSheet, Text, View, TextInput, Switch, Pressable, Alert, Modal, TouchableOpacity, Platform } from 'react-native';
import { Picker } from '@react-native-picker/picker';
import { StatusBar } from 'expo-status-bar';

export default function App() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [ticketType, setTicketType] = useState('Звичайний');
  const [seatNeeded, setSeatNeeded] = useState(false);
  const [comment, setComment] = useState('');
  const [errors, setErrors] = useState({});
  const [modalVisible, setModalVisible] = useState(false);

  const validate = () => {
    let valid = true;
    let newErrors = {};
    if (!firstName.trim()) {
      newErrors.firstName = 'Введіть ім\'я';
      valid = false;
    }
    if (!lastName.trim()) {
      newErrors.lastName = 'Введіть прізвище';
      valid = false;
    }
    if (!email.trim()) {
      newErrors.email = 'Введіть email';
      valid = false;
    } else if (!email.includes('@')) {
      newErrors.email = 'Email має містити @';
      valid = false;
    }
    setErrors(newErrors);
    return valid;
  };

  const handleRegister = () => {
    if (validate()) {
      setModalVisible(true);
    } else {
      Alert.alert('Помилка', 'Будь ласка, перевірте правильність заповнення форми.');
    }
  };

  const handleModalClose = () => {
    setModalVisible(false);
    setFirstName('');
    setLastName('');
    setEmail('');
    setTicketType('Звичайний');
    setSeatNeeded(false);
    setComment('');
    setErrors({});
  };

  const isFormValid = firstName.trim() && lastName.trim() && email.trim() && email.includes('@');

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Реєстрація на подію</Text>
      <View style={styles.formGroup}>
        <Text style={styles.label}>Ім'я <Text style={styles.required}>*</Text></Text>
        <TextInput
          style={[styles.input, errors.firstName && styles.inputError]}
          value={firstName}
          onChangeText={setFirstName}
          placeholder="Введіть ім'я"
        />
        {errors.firstName && <Text style={styles.errorText}>{errors.firstName}</Text>}
      </View>
      <View style={styles.formGroup}>
        <Text style={styles.label}>Прізвище <Text style={styles.required}>*</Text></Text>
        <TextInput
          style={[styles.input, errors.lastName && styles.inputError]}
          value={lastName}
          onChangeText={setLastName}
          placeholder="Введіть прізвище"
        />
        {errors.lastName && <Text style={styles.errorText}>{errors.lastName}</Text>}
      </View>
      <View style={styles.formGroup}>
        <Text style={styles.label}>Email <Text style={styles.required}>*</Text></Text>
        <TextInput
          style={[styles.input, errors.email && styles.inputError]}
          value={email}
          onChangeText={setEmail}
          placeholder="example@email.com"
          keyboardType="email-address"
          autoCapitalize="none"
        />
        {errors.email && <Text style={styles.errorText}>{errors.email}</Text>}
      </View>
      <View style={styles.formGroup}>
        <Text style={styles.label}>Тип квитка</Text>
        <View style={styles.pickerWrapper}>
          <Picker
            selectedValue={ticketType}
            onValueChange={setTicketType}
            style={Platform.OS === 'ios' ? styles.pickerIOS : styles.picker}
          >
            <Picker.Item label="Звичайний" value="Звичайний" />
            <Picker.Item label="Студент" value="Студент" />
            <Picker.Item label="VIP" value="VIP" />
          </Picker>
        </View>
      </View>
      <View style={styles.formGroupRow}>
        <Text style={styles.label}>Потрібне місце для сидіння?</Text>
        <Switch value={seatNeeded} onValueChange={setSeatNeeded} />
      </View>
      <View style={styles.formGroup}>
        <Text style={styles.label}>Коментар</Text>
        <TextInput
          style={[styles.input, styles.textArea]}
          value={comment}
          onChangeText={setComment}
          placeholder="Ваш коментар (необов'язково)"
          multiline
          numberOfLines={3}
        />
      </View>
      <Pressable
        style={[styles.button, !isFormValid && styles.buttonDisabled]}
        onPress={handleRegister}
        disabled={!isFormValid}
      >
        <Text style={styles.buttonText}>Зареєструватися</Text>
      </Pressable>
      <Modal
        visible={modalVisible}
        transparent
        animationType="slide"
        onRequestClose={handleModalClose}
      >
        <View style={styles.modalOverlay}>
          <View style={styles.modalContent}>
            <Text style={styles.modalTitle}>Дякуємо, {firstName}!</Text>
            <Text style={styles.modalText}>
              Ви зареєстровані як {ticketType}-учасник.
            </Text>
            <Text style={styles.modalText}>Email: {email}</Text>
            <Text style={styles.modalText}>Місце для сидіння: {seatNeeded ? 'Так' : 'Ні'}</Text>
            {comment ? <Text style={styles.modalText}>Коментар: {comment}</Text> : null}
            <TouchableOpacity style={styles.closeButton} onPress={handleModalClose}>
              <Text style={styles.closeButtonText}>OK</Text>
            </TouchableOpacity>
          </View>
        </View>
      </Modal>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: '#f7f7f7',
    alignItems: 'center',
    justifyContent: 'center',
    padding: 20,
  },
  title: {
    fontSize: 24,
    fontWeight: 'bold',
    marginBottom: 24,
    color: '#222',
  },
  formGroup: {
    width: '100%',
    marginBottom: 16,
  },
  formGroupRow: {
    width: '100%',
    marginBottom: 16,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'space-between',
  },
  label: {
    fontSize: 16,
    marginBottom: 4,
    color: '#333',
  },
  required: {
    color: '#e53935',
  },
  input: {
    borderWidth: 1,
    borderColor: '#bbb',
    borderRadius: 6,
    padding: 10,
    backgroundColor: '#fff',
    fontSize: 16,
  },
  inputError: {
    borderColor: '#e53935',
  },
  errorText: {
    color: '#e53935',
    fontSize: 13,
    marginTop: 2,
  },
  pickerWrapper: {
    borderWidth: 1,
    borderColor: '#bbb',
    borderRadius: 6,
    overflow: 'hidden',
    backgroundColor: '#fff',
  },
  picker: {
    height: 44,
    width: '100%',
  },
  pickerIOS: {
    height: 120,
    width: '100%',
  },
  textArea: {
    minHeight: 60,
    textAlignVertical: 'top',
  },
  button: {
    backgroundColor: '#1976d2',
    paddingVertical: 14,
    borderRadius: 6,
    alignItems: 'center',
    marginTop: 10,
    width: '100%',
  },
  buttonDisabled: {
    backgroundColor: '#90caf9',
  },
  buttonText: {
    color: '#fff',
    fontSize: 18,
    fontWeight: 'bold',
  },
  modalOverlay: {
    flex: 1,
    backgroundColor: 'rgba(0,0,0,0.3)',
    justifyContent: 'center',
    alignItems: 'center',
  },
  modalContent: {
    backgroundColor: '#fff',
    borderRadius: 10,
    padding: 24,
    alignItems: 'center',
    width: 300,
    shadowColor: '#000',
    shadowOffset: { width: 0, height: 2 },
    shadowOpacity: 0.2,
    shadowRadius: 4,
    elevation: 5,
  },
  modalTitle: {
    fontSize: 22,
    fontWeight: 'bold',
    marginBottom: 10,
    color: '#1976d2',
  },
  modalText: {
    fontSize: 16,
    marginBottom: 6,
    color: '#333',
    textAlign: 'center',
  },
  closeButton: {
    marginTop: 16,
    backgroundColor: '#1976d2',
    borderRadius: 6,
    paddingVertical: 10,
    paddingHorizontal: 30,
  },
  closeButtonText: {
    color: '#fff',
    fontSize: 16,
    fontWeight: 'bold',
  },
});
